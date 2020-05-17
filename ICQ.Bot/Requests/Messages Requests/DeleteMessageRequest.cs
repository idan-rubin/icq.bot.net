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
        public IEnumerable<long> MessageIds { get; }

        public DeleteMessageRequest(ChatId chatId, IEnumerable<long> messageIds)
            : base("/messages/deleteMessages", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageIds = messageIds;
        }

        public override NameValueCollection BuildParameters()
        {
            string msgIds = JsonConvert.SerializeObject(MessageIds);
            var result = new NameValueCollection
            {
                { "chatId", ChatId },
                { "mgsId", msgIds }
            };

            return result;
        }
    }
}
