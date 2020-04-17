using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetFileRequest : RequestBase<File>
    {
        [JsonProperty(Required = Required.Always)]
        public string FileId { get; }

        public GetFileRequest(string fileId)
            : base("getFile")
        {
            FileId = fileId;
        }
    }
}
