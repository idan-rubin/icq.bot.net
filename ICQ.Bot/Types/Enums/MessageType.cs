using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ICQ.Bot.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum MessageType
    {
        Unknown = 0,
        Text,
        Photo,
        Audio,
        Video,
        Voice,
        Document,
        Sticker,
        Location,
        Contact,
        Venue,
        Game,

        [EnumMember(Value = "video_note")]
        VideoNote,
        Invoice,

        [EnumMember(Value = "successful_payment")]
        SuccessfulPayment,

        [EnumMember(Value = "website_connected")]
        WebsiteConnected,

        [EnumMember(Value = "chat_members_added")]
        ChatMembersAdded,

        [EnumMember(Value = "chat_member_left")]
        ChatMemberLeft,

        [EnumMember(Value = "chat_title_changed")]
        ChatTitleChanged,

        [EnumMember(Value = "chat_photo_changed")]
        ChatPhotoChanged,

        [EnumMember(Value = "message_pinned")]
        MessagePinned,

        [EnumMember(Value = "chat_photo_deleted")]
        ChatPhotoDeleted,

        [EnumMember(Value = "group_created")]
        GroupCreated,

        [EnumMember(Value = "supergroup_created")]
        SupergroupCreated,

        [EnumMember(Value = "channel_created")]
        ChannelCreated,

        [EnumMember(Value = "migrated_to_supergroup")]
        MigratedToSupergroup,

        [EnumMember(Value = "migrated_from_group")]
        MigratedFromGroup,

        [Obsolete("Check if Message.Animation has value instead")]
        Animation,

        [EnumMember(Value = "poll")]
        Poll,

        Dice,
    }
}
