using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

            string tempAction = Action.ToString();
            string newAction = char.ToLower(tempAction[0]) + tempAction.Substring(1);
            QueryString = string.Format("?chatId={0}&actions=[{1}]", ChatId, newAction);
        }
    }
}
