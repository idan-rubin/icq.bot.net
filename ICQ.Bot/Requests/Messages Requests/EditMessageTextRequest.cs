using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class EditMessageTextRequest : RequestBase<MessagesResponse>,
                                          IInlineReplyMarkupMessage
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public int MessageId { get; }

        [JsonProperty(Required = Required.Always)]
        public string Text { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableWebPagePreview { get; set; }

        /// <inheritdoc cref="IInlineReplyMarkupMessage.ReplyMarkup" />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        public EditMessageTextRequest(ChatId chatId, int messageId, string text)
            : base("/messages/editText", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageId = messageId;
            Text = text;
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("chatId={0}&msgId={1}&text={2}", ChatId, MessageId, Text);
            if (ReplyMarkup != null)
            {
                string markup = JsonConvert.SerializeObject(ReplyMarkup);
                queryString = string.Format("{0}&inlineKeyboardMarkup={1}", queryString, markup);
            }

            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
