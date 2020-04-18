using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Converters;
using ICQ.Bot.Types;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetChatRequest : RequestBase<ChatInfo>
    {
        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(ChatIdConverter))]
        public ChatId ChatId { get; }

        public GetChatRequest(ChatId chatId)
            : base("/chats/getInfo", HttpMethod.Get)
        {
            ChatId = chatId;

            QueryString = string.Format("?chatId={0}", ChatId);
        }
    }
}
