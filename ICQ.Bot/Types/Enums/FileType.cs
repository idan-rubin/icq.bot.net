using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ICQ.Bot.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum FileType
    {
        Stream,
        Id,
        Url
    }
}