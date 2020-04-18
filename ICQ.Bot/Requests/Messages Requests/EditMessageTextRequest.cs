using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Web;

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

        public EditMessageTextRequest(ChatId chatId, int messageId, string text, InlineKeyboardMarkup replyMarkup)
            : base("/messages/editText", HttpMethod.Post)
        {
            ChatId = chatId;
            MessageId = messageId;
            ReplyMarkup = replyMarkup;

            Parameters.Add("chatId", ChatId);
            Parameters.Add("msgId", MessageId.ToString());
            Parameters.Add("text", Text);

            if (ReplyMarkup != null)
            {
                string markup = JsonConvert.SerializeObject(ReplyMarkup);
                Parameters.Add("inlineKeyboardMarkup", markup);
            }
        }
    }
}
