using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace ICQ.Bot.Types.ReplyMarkups
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; }
        public InlineKeyboardMarkup(InlineKeyboardButton inlineKeyboardButton)
            : this(new[] { inlineKeyboardButton }) { }

        public InlineKeyboardMarkup(IEnumerable<InlineKeyboardButton> inlineKeyboardRow)
        {
            InlineKeyboard = new[]
            {
                inlineKeyboardRow
            };
        }

        [JsonConstructor]
        public InlineKeyboardMarkup(IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboard)
        {
            InlineKeyboard = inlineKeyboard;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(InlineKeyboard);
        }

        public static implicit operator InlineKeyboardMarkup(InlineKeyboardButton button) =>
            button == null
                ? default
                : new InlineKeyboardMarkup(button);

        public static implicit operator InlineKeyboardMarkup(string buttonText) =>
            buttonText == null
                ? default
                : new InlineKeyboardMarkup(buttonText);

        public static implicit operator InlineKeyboardMarkup(IEnumerable<InlineKeyboardButton>[] inlineKeyboard) =>
            inlineKeyboard == null
                ? null
                : new InlineKeyboardMarkup(inlineKeyboard);

        public static implicit operator InlineKeyboardMarkup(InlineKeyboardButton[] inlineKeyboard) =>
            inlineKeyboard == null
                ? null
                : new InlineKeyboardMarkup(inlineKeyboard);
    }

    public static class InlineKeyboardMarkupHelper
    {
        internal static InlineKeyboardMarkup ToInlineKeyboardMarkup(this string value)
        {
            var result = new InlineKeyboardMarkup(JsonConvert.DeserializeObject<IEnumerable<InlineKeyboardButton>>(value));
            return result;
        }

        internal static string ToStringValue(this InlineKeyboardMarkup value)
        {
            Console.WriteLine("booom!");
            return JsonConvert.SerializeObject(value.InlineKeyboard);
        }
    }
}
