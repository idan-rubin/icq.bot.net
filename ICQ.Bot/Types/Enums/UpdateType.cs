using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ICQ.Bot.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum UpdateType
    {
        Unknown = 0,
        Message,

        [EnumMember(Value = "inline_query")]
        InlineQuery,

        [EnumMember(Value = "chosen_inline_result")]
        ChosenInlineResult,

        [EnumMember(Value = "callback_query")]
        CallbackQuery,

        [EnumMember(Value = "edited_message")]
        EditedMessage,

        [EnumMember(Value = "channel_post")]
        ChannelPost,

        [EnumMember(Value = "edited_channel_post")]
        EditedChannelPost,

        [EnumMember(Value = "shipping_query")]
        ShippingQuery,

        [EnumMember(Value = "pre_checkout_query")]
        PreCheckoutQuery,

        [EnumMember(Value = "poll")]
        Poll,

        [EnumMember(Value = "poll_answer")]
        PollAnswer,
    }
}
