using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InlineQuery
    {
        [JsonProperty(Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public User From { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Query { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Offset { get; set; }
    }
}
