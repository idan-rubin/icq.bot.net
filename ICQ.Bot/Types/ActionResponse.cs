using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ActionResponse
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Ok { get; set; }
    }
}
