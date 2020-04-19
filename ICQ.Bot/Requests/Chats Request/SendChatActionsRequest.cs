using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

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

        public override HttpContent ToHttpContent()
        {
            string tempAction = Action.ToString();
            string newAction = string.Format("{0}{1}", char.ToLower(tempAction[0]), tempAction.Substring(1));
            string queryString = string.Format("chatId={0}&actions=[{1}]", ChatId, newAction);
            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
