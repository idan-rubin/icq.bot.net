using System.Collections.Generic;
using System.Net.Http;

namespace ICQ.Bot.Requests.Abstractions
{
    public interface IRequest<TResponse>
    {
        HttpMethod Method { get; }
        string MethodName { get; }
        HttpContent ToHttpContent();
    }
}
