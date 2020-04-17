using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Helpers;
using ICQ.Bot.Types.InputFiles;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class FileRequestBase<TResponse> : RequestBase<TResponse>
    {
        protected FileRequestBase(string methodName)
            : base(methodName)
        { }

        protected FileRequestBase(string methodName, HttpMethod method)
            : base(methodName, method)
        { }

        protected MultipartFormDataContent ToMultipartFormDataContent(string fileParameterName, InputFileStream inputFile)
        {
            var multipartContent = GenerateMultipartFormDataContent(fileParameterName);

            multipartContent.AddStreamContent(inputFile.Content, fileParameterName, inputFile.FileName);

            return multipartContent;
        }

        protected MultipartFormDataContent GenerateMultipartFormDataContent(params string[] exceptPropertyNames)
        {
            var multipartContent = new MultipartFormDataContent(Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks);

            var stringContents = JObject.FromObject(this)
                .Properties()
                .Where(prop => exceptPropertyNames?.Contains(prop.Name) == false)
                .Select(prop => new
                {
                    prop.Name,
                    Content = new StringContent(prop.Value.ToString())
                });
            foreach (var strContent in stringContents)
                multipartContent.Add(strContent.Content, strContent.Name);

            return multipartContent;
        }
    }
}
