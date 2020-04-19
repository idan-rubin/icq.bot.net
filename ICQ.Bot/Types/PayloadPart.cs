using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PayloadPart
    {
        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(Required = Required.Always)]
        public PayloadPartPayload Payload { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PayloadPartPayload
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public UpdatePayload Message { get; set; }
    }
}
