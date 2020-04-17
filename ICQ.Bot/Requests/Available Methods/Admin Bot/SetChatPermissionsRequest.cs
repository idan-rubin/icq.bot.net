using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SetChatPermissionsRequest : RequestBase<bool>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public ChatPermissions Permissions { get; }
        public SetChatPermissionsRequest(ChatId chatId, ChatPermissions permissions)
            : base("setChatPermissions")
        {
            ChatId = chatId;
            Permissions = permissions;
        }
    }
}
