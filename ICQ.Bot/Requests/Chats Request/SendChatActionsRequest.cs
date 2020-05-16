using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendChatActionsRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public ChatAction Action { get; }

        public SendChatActionsRequest(ChatId chatId, ChatAction action)
            : base("/chats/sendActions", HttpMethod.Get)
        {
            ChatId = chatId;
            Action = action;
        }

        public override NameValueCollection BuildParameters()
        {
            string tempAction = Action.ToString();
            string newAction = string.Format("{0}{1}", char.ToLower(tempAction[0]), tempAction.Substring(1));
            string action = string.Format("[{0}]", newAction);
            var result = new NameValueCollection
            {
                { "chatId", ChatId },
                { "actions", action }
            };

            return result;
        }
    }
}
