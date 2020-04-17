using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetMeRequest : ParameterlessRequest<User>
    {
        public GetMeRequest()
            : base("/self/get")
        { }
    }
}
