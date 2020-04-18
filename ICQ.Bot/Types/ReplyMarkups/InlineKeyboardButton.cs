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

        public static implicit operator InlineKeyboardButton(string textAndCallbackData) =>
            textAndCallbackData == null
                ? default
                : WithCallbackData(textAndCallbackData);
    }
}
