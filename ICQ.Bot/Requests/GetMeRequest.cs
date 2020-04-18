using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GetMeRequest : ParameterlessRequest<User>
    {
        public GetMeRequest()
            : base("/self/get", HttpMethod.Get)
        { }
    }
}
