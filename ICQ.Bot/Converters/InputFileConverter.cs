using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.InputFiles;

namespace ICQ.Bot.Converters
{
    internal class InputFileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            objectType.GetTypeInfo().IsSubclassOf(typeof(InputFileStream));

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var input = (IInputFile)value;
            switch (input.FileType)
            {
                case FileType.Stream:
                    writer.WriteValue(null as object);
                    break;
                case FileType.Id when value is InputICQFile file:
                    writer.WriteValue(file.FileId);
                    break;
                case FileType.Url when value is InputOnlineFile file:
                    writer.WriteValue(file.Url);
                    break;
                default:
                    throw new NotSupportedException("File Type is not supported");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = JToken.ReadFrom(reader).Value<string>();
            if (value == null)
            {
                return new InputFileStream(Stream.Null);
            }
            else
            {
                if (Uri.TryCreate(value, UriKind.Absolute, out Uri _))
                    return new InputOnlineFile(value);
                else
                    return new InputICQFile(value);
            }
        }
    }
}
