using System.Collections.Specialized;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ParameterlessRequest<TResult> : RequestBase<TResult>
    {
        public ParameterlessRequest(string methodName, HttpMethod method)
            : base(methodName, method)
        {
        }

        public override NameValueCollection BuildParameters()
        {
            return null;
        }
    }
}
