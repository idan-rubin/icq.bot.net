using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BotCommand
    {
        [JsonProperty(Required = Required.Always)]
        public string Command { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
    }
}
