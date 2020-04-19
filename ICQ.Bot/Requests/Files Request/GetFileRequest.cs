using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Web;
using System.Text;

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
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("fileId={0}", FileId);
            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
