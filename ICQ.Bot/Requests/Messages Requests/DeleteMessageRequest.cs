using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DeleteMessageRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public long MessageId { get; }

        public DeleteMessageRequest(ChatId chatId, long messageId)
            : base("/messages/deleteMessages", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageId = messageId;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "chatId", ChatId },
                { "msgId", MessageId.ToString() }
            };

            return result;
        }
    }
}
