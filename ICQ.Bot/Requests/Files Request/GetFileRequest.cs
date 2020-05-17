using ICQ.Bot.Exceptions;
using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetFileInfoRequest : RequestBase<File>
    {
        [JsonProperty(Required = Required.Always)]
        public string FileId { get; }

        public GetFileInfoRequest(string fileId)
            : base("/files/getInfo", HttpMethod.Get)
        {
            if (string.IsNullOrWhiteSpace(fileId))
            {
                throw new InvalidParameterException(nameof(fileId));
            }

            FileId = fileId;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "fileId", FileId }
            };

            return result;
        }
    }
}
