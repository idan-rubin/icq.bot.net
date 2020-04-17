using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Requests.Abstractions;
using System.Collections.Generic;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public HttpMethod Method { get; }

        [JsonIgnore]
        public string MethodName { get; protected set; }

        [JsonIgnore]
        public string QueryString { get; protected set; }

        [JsonIgnore]
        //https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
        public Dictionary<string, string> Parameters { get; protected set; }

        protected RequestBase(string methodName)
            : this(methodName, HttpMethod.Post)
        { }

        protected RequestBase(string methodName, HttpMethod method)
        {
            MethodName = methodName;
            Method = method;
            Parameters = new Dictionary<string, string>();
        }

        public virtual HttpContent ToHttpContent()
        {
            string payload = JsonConvert.SerializeObject(this);
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }

        [JsonIgnore]
        public bool IsWebhookResponse { get; set; }


        [JsonProperty("method", DefaultValueHandling = DefaultValueHandling.Ignore)]
        internal string WebHookMethodName => IsWebhookResponse ? MethodName : default;
    }
}
