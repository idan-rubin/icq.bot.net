using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Converters;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetChatRequest : RequestBase<ChatInfo>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        public GetChatRequest(ChatId chatId)
            : base("/chats/getInfo", HttpMethod.Get)
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
