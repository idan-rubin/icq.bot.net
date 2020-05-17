using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;

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
        public long ReplyToMessageId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        public SendMessageRequest(ChatId chatId, string text)
            : base("/messages/sendText", HttpMethod.Get)
        {
            ChatId = chatId;
            Text = text;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "chatId", ChatId }
            };

            if (!string.IsNullOrWhiteSpace(Text))
            {
                result.Add("text", Text);
            }

            if (ReplyMarkup != null)
            {
                string markup = ReplyMarkup.ToJson();
                result.Add("inlineKeyboardMarkup", markup);
            }

            return result;
        }
    }
}
