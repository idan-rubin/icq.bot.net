using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.InputFiles;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendDocumentRequest : FileRequestBase<MessagesResponse>,
                                       INotifiableMessage,
                                       IReplyMessage,
                                       IReplyMarkupMessage<IReplyMarkup>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public InputOnlineFile Document { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMedia Thumb { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ReplyToMessageId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableNotification { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        public SendDocumentRequest(ChatId chatId, InputOnlineFile document)
            : base("/messages/sendFile", HttpMethod.Post)
        {
            ChatId = chatId;
            Document = document;
        }

        public override HttpContent ToHttpContent()
        {
            //https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "chatId", ChatId }
            };

            if (Document != null)
            {
                parameters.Add("fileId", Document.FileId);
            }

            if (!string.IsNullOrWhiteSpace(Caption))
            {
                parameters.Add("caption", Caption);
            }

            if (ReplyMarkup != null)
            {
                string markup = JsonConvert.SerializeObject(ReplyMarkup);
                parameters.Add("inlineKeyboardMarkup", markup);
            }

            var encodedContent = new FormUrlEncodedContent(parameters);
            return encodedContent;
        }
    }
}
