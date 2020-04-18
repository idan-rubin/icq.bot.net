using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;
using System.Collections.Generic;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DeleteMessageRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public IEnumerable<int> MessageIds { get; }

        public DeleteMessageRequest(ChatId chatId, IEnumerable<int> messageIds)
            : base("/messages/deleteMessages", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageIds = messageIds;

            string msgIds = JsonConvert.SerializeObject(MessageIds);
            QueryString = string.Format("?chatId={0}&mgsId={1}", ChatId, msgIds);
        }
    }
}
