using ICQ.Bot.Helpers;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.InputFiles;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class FileRequestBase<TResponse> : RequestBase<TResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; protected set; }

        [JsonProperty(Required = Required.Always)]
        public InputOnlineFile Document { get; protected set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMedia Thumb { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ReplyToMessageId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableNotification { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        protected FileRequestBase(string methodName, HttpMethod method)
            : base(methodName, method)
        { }

        public MultipartFormDataContent ToMultipartFormDataContent(string fileParameterName, InputFileStream inputFile)
        {
            string boundary = Guid.NewGuid().ToString();
            var multipartContent = new MultipartFormDataContent(boundary);

            //https://stackoverflow.com/questions/30926645/httpcontent-boundary-double-quotes
            //https://blog.codetitans.pl/post/quoted-boundary-is-sometimes-not-acceptable/
            multipartContent.Headers.Remove("Content-Type");
            multipartContent.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);

            multipartContent.AddStreamContent(inputFile.Content, fileParameterName, inputFile.FileName);
            return multipartContent;
        }
    }
}
