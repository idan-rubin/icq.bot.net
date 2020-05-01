using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ICQ.Bot.Types
{
    public enum UpdateType
    {
        NewMesssage,
        EditedMessage,
        DeletedMessage,
        PinnedMessage,
        UnpinnedMessage,
        NewChatMembers,
        LeftChatMembers,
        CallbackQuery,
    }

    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Update
    {
        [JsonProperty(Required = Required.Always)]
        public int EventId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public UpdatePayload Payload { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime EditedTimestamp { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CallbackData { get; set; }
    }
}
