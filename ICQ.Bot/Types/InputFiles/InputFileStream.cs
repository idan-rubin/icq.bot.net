using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Converters;
using ICQ.Bot.Types.Enums;

namespace ICQ.Bot.Types.InputFiles
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    [JsonConverter(typeof(InputFileConverter))]
    public class InputFileStream : IInputFile
    {
        public Stream Content { get; protected set; }
        public string FileName { get; set; }
        public virtual FileType FileType => FileType.Stream;

        protected InputFileStream()
        { }

        public InputFileStream(Stream content)
            : this(content, default)
        { }

        public InputFileStream(Stream content, string fileName)
        {
            Content = content;
            FileName = fileName;
        }

        public static implicit operator InputFileStream(Stream stream) =>
            stream == null
                ? default
                : new InputFileStream(stream);
    }
}
