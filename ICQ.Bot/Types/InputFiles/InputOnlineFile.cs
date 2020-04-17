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
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; protected set; }

        /// <inheritdoc cref="IInputFile.FileType"/>
        public override FileType FileType
        {
            get
            {
                if (Content != null) return FileType.Stream;
                if (FileId != null) return FileType.Id;
                if (Url != null) return FileType.Url;
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

        public InputOnlineFile(string value)
        {
            if (Uri.TryCreate(value, UriKind.Absolute, out Uri _))
            {
                Url = value;
            }
            else
            {
                FileId = value;
            }
        }

        public InputOnlineFile(Uri url)
        {
            Url = url.AbsoluteUri;
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
