using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ICQ.Bot.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ParseMode
    {
        Default = 0,
        Markdown,
        Html,
        MarkdownV2,
    }
}
