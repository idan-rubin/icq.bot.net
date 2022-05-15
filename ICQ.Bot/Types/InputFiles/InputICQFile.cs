using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Converters;
using ICQ.Bot.Types.Enums;

namespace ICQ.Bot.Types.InputFiles
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    [JsonConverter(typeof(InputFileConverter))]
    public class InputICQFile : InputFileStream
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileId { get; protected set; }

        public override FileType FileType
        {
            get
            {
                if (Content != null) return FileType.Stream;
                if (FileId != null) return FileType.Id;
                throw new InvalidOperationException("Not a valid Input File");
            }
        }

        protected InputICQFile()
        { }

        public InputICQFile(Stream content)
            : this(content, default)
        { }

        public InputICQFile(Stream content, string fileName)
        {
            Content = content;
            FileName = fileName;
        }

        public InputICQFile(string fileId)
        {
            FileId = fileId;
        }

        public static implicit operator InputICQFile(Stream stream) =>
            stream == null
                ? default
                : new InputICQFile(stream);

        public static implicit operator InputICQFile(string fileId) =>
            fileId == null
                ? default
                : new InputICQFile(fileId);
    }
}
