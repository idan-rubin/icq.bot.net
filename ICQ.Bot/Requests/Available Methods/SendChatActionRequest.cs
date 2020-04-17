using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendChatActionRequest : RequestBase<bool>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public ChatAction Action { get; }

        public SendChatActionRequest(ChatId chatId, ChatAction action)
            : base("sendChatAction")
        {
            ChatId = chatId;
            Action = action;
        }
    }
}
