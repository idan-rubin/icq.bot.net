using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InputMediaDocument : InputMediaBase, IInputMediaThumb
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMedia Thumb { get; set; }

        public InputMediaDocument(InputMedia media)
        {
            Type = "document";
            Media = media;
        }
    }
}
