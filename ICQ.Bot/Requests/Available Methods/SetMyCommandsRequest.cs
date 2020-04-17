using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SetMyCommandsRequest : RequestBase<bool>
    {
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<BotCommand> Commands { get; }

        public SetMyCommandsRequest(IEnumerable<BotCommand> commands)
            : base("setMyCommands")
        {
            Commands = commands;
        }
    }
}
