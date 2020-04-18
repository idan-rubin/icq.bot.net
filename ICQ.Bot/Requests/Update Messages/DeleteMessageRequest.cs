using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DeleteMessageRequest : RequestBase<bool>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public int MessageId { get; }

        public DeleteMessageRequest(ChatId chatId, int messageId)
            : base("deleteMessage", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageId = messageId;
        }
    }
}
