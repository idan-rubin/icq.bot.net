using ICQ.Bot.Types.InputFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InputMedia : InputOnlineFile
    {
        public InputMedia(Stream content, string fileName)
            : base(content, fileName)
        {
        }

        public InputMedia(string fileId)
            : base(fileId)
        {
        }

        public static implicit operator InputMedia(string value) =>
            value == null
                ? null
                : new InputMedia(value);
    }
}
