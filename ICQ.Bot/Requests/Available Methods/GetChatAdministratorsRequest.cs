using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;

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

            QueryString = string.Format("?chatId={0}", ChatId);
        }
    }
}
