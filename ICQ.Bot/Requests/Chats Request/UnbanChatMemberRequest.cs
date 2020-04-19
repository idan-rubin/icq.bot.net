using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Text;

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
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("chatId={0}&userId={1}", ChatId, UserId);
            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
