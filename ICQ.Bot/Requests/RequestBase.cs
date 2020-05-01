using ICQ.Bot.Requests.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public HttpMethod Method { get; }

        [JsonIgnore]
        public string MethodName { get; protected set; }

        protected RequestBase(string methodName, HttpMethod method)
        {
            MethodName = methodName;
            Method = method;
        }

        public virtual HttpContent ToHttpContent()
        {
            return null;
        }
    }
}
