using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Web;

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
            FileId = fileId;
            FileId = HttpUtility.UrlEncode(FileId);
            QueryString = string.Format("?fileId={0}", FileId);
        }
    }
}
