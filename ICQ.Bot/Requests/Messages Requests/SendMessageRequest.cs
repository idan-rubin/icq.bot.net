using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.ReplyMarkups;
using System.Net.Http;
using System.Web;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendMessageRequest : RequestBase<MessagesResponse>,
                                      INotifiableMessage,
                                      IReplyMessage,
                                      IReplyMarkupMessage<IReplyMarkup>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public string Text { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableWebPagePreview { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableNotification { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ReplyToMessageId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        public SendMessageRequest(ChatId chatId, string text, IReplyMarkup replyMarkup)
            : base("/messages/sendText", HttpMethod.Get)
        {
            ChatId = chatId;
            Text = text;
            ReplyMarkup = replyMarkup;

            QueryString = string.Format("?chatId={0}&text={1}", ChatId, Text);
            if (ReplyMarkup != null)
            {
                string markup = JsonConvert.SerializeObject(ReplyMarkup);
                markup = HttpUtility.UrlEncode(markup);
                QueryString = string.Format("{0}&inlineKeyboardMarkup={1}", QueryString, markup);
            }
        }
    }
}
