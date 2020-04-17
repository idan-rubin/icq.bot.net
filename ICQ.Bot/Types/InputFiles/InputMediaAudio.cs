using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class InputMediaAudio : InputMediaBase, IInputMediaThumb
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Title { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Performer { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Duration { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMedia Thumb { get; set; }

        public InputMediaAudio(InputMedia media)
        {
            Type = "audio";
            Media = media;
        }
    }
}
