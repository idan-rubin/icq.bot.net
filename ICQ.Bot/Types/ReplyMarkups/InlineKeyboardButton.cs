using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types.ReplyMarkups
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InlineKeyboardButton : IKeyboardButton
    {
        [JsonProperty(Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CallbackData { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SwitchInlineQuery { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SwitchInlineQueryCurrentChat { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Pay { get; set; }

        public static InlineKeyboardButton WithUrl(string text, string url) =>
            new InlineKeyboardButton
            {
                Text = text,
                Url = url
            };

        public static InlineKeyboardButton WithCallbackData(string textAndCallbackData) =>
            new InlineKeyboardButton
            {
                Text = textAndCallbackData,
                CallbackData = textAndCallbackData
            };

        public static InlineKeyboardButton WithCallbackData(string text, string callbackData) =>
            new InlineKeyboardButton
            {
                Text = text,
                CallbackData = callbackData
            };

        public static InlineKeyboardButton WithSwitchInlineQuery(string text, string query = "") =>
            new InlineKeyboardButton
            {
                Text = text,
                SwitchInlineQuery = query
            };

        public static InlineKeyboardButton WithSwitchInlineQueryCurrentChat(string text, string query = "") =>
            new InlineKeyboardButton
            {
                Text = text,
                SwitchInlineQueryCurrentChat = query
            };

        public static InlineKeyboardButton WithPayment(string text) =>
            new InlineKeyboardButton
            {
                Text = text,
                Pay = true
            };


        public static implicit operator InlineKeyboardButton(string textAndCallbackData) =>
            textAndCallbackData == null
                ? default
                : WithCallbackData(textAndCallbackData);
    }
}
