using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class EditMessageTextRequest : RequestBase<MessagesResponse>,
                                          IInlineReplyMarkupMessage
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public long MessageId { get; }

        [JsonProperty(Required = Required.Always)]
        public string Text { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableWebPagePreview { get; set; }

        /// <inheritdoc cref="IInlineReplyMarkupMessage.ReplyMarkup" />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        public EditMessageTextRequest(ChatId chatId, long messageId, string text)
            : base("/messages/editText", HttpMethod.Get)
        {
            ChatId = chatId;
            MessageId = messageId;
            Text = text;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "chatId", ChatId },
                { "mgsId", MessageId.ToString() },
                { "text", Text },
            };

            if (ReplyMarkup != null)
            {
                string markup = ReplyMarkup.ToJson();
                result.Add("inlineKeyboardMarkup", markup);
            }

            return result;
        }
    }
}
