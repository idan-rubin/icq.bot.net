using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Message
    {
        [JsonProperty(Required = Required.Always)]
        public long MsgId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Chat Chat { get; set; }

        [JsonProperty(Required = Required.Always)]
        public User From { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileId { get; set; }
    }
}
