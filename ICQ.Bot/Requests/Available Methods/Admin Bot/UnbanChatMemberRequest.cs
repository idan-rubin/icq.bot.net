using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class UnbanChatMemberRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public int UserId { get; }

        public UnbanChatMemberRequest(ChatId chatId, int userId)
            : base("/chats/unblockUser", HttpMethod.Get)
        {
            ChatId = chatId;
            UserId = userId;

            QueryString = string.Format("?chatId={0}&userId={1}", ChatId, UserId);
        }
    }
}
