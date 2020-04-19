using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetChatAdministratorsRequest : RequestBase<ChatAdmins>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        public GetChatAdministratorsRequest(ChatId chatId)
            : base("/chats/getAdminis", HttpMethod.Get)
        {
            ChatId = chatId;
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("chatId={0}", ChatId);
            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
