using ICQ.Bot.Exceptions;
using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DeleteMessagesRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public IEnumerable<long> MessageIds { get; }

        public DeleteMessagesRequest(ChatId chatId, IEnumerable<long> messageIds)
            : base("/messages/deleteMessages", HttpMethod.Get)
        {
            if (messageIds == null || messageIds.Count() == 0)
            {
                throw new InvalidParameterException(nameof(messageIds));
            }

            ChatId = chatId;
            MessageIds = messageIds;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "chatId", ChatId },
            };

            foreach(var messageId in MessageIds)
            {
                result.Add("msgId", messageId.ToString());
            }

            return result;
        }
    }
}
