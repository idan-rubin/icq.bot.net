using System.IO;
using Newtonsoft.Json;
using ICQ.Bot.Converters;
using ICQ.Bot.Types.InputFiles;

namespace ICQ.Bot.Types
{
    [JsonConverter(typeof(InputMediaConverter))]
    public class InputMedia : InputOnlineFile
    {
        public InputMedia(Stream content, string fileName)
            : base(content, fileName)
        {
        }

        public InputMedia(string value)
            : base(value)
        {
        }

        public static implicit operator InputMedia(string value) =>
            value == null
                ? null
                : new InputMedia(value);
    }
}
