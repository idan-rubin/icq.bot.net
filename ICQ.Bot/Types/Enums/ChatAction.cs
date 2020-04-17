using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ICQ.Bot.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum ChatAction
    {
        Typing,

        [EnumMember(Value = "upload_photo")]
        UploadPhoto,

        [EnumMember(Value = "record_video")]
        RecordVideo,

        [EnumMember(Value = "upload_video")]
        UploadVideo,

        [EnumMember(Value = "record_audio")]
        RecordAudio,

        [EnumMember(Value = "upload_audio")]
        UploadAudio,

        [EnumMember(Value = "upload_document")]
        UploadDocument,

        [EnumMember(Value = "find_location")]
        FindLocation,

        [EnumMember(Value = "record_video_note")]
        RecordVideoNote,

        [EnumMember(Value = "upload_video_note")]
        UploadVideoNote,
    }
}
