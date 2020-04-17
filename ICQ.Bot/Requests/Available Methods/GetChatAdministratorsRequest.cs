using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetChatAdministratorsRequest : RequestBase<ChatMember[]>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        public GetChatAdministratorsRequest(ChatId chatId)
            : base("getChatAdministrators")
        {
            ChatId = chatId;
        }
    }
}
