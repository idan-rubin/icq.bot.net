using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LeaveChatRequest : RequestBase<bool>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        public LeaveChatRequest(ChatId chatId)
            : base("leaveChat")
        {
            ChatId = chatId;
        }
    }
}
