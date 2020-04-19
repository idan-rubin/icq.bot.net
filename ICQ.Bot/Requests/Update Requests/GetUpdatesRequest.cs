using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Requests
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetUpdatesRequest : RequestBase<Updates>
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Offset { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Timeout { get; private set; }

        public GetUpdatesRequest(int offset, int timeout)
            : base("/events/get", HttpMethod.Get)
        {
            Offset = offset;
            Timeout = timeout;
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("lastEventId={0}&pollTime={1}", Offset, Timeout);
            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
