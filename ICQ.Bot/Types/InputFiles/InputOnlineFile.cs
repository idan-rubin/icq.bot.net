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
    public class InputOnlineFile : InputICQFile
    {
        /// <inheritdoc cref="IInputFile.FileType"/>
        public override FileType FileType
        {
            get
            {
                if (Content != null) return FileType.Stream;
                if (FileId != null) return FileType.Id;
                throw new InvalidOperationException("Not a valid InputFile");
            }
        }

        public InputOnlineFile(Stream content)
            : this(content, default)
        {
        }

        public InputOnlineFile(Stream content, string fileName)
        {
            Content = content;
            FileName = fileName;
        }

        public InputOnlineFile(string fileId)
        {
            FileId = fileId;
        }

        public static implicit operator InputOnlineFile(Stream stream) =>
            stream == null
                ? default
                : new InputOnlineFile(stream);

        public static implicit operator InputOnlineFile(string value) =>
            value == null
                ? default
                : new InputOnlineFile(value);
    }
}
