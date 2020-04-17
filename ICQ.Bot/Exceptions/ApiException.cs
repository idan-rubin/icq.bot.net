using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Exceptions
{
    public class ApiRequestException : Exception
    {
        public virtual int ErrorCode { get; private set;  }
        public ResponseParameters Parameters { get; private set; }
        public ApiRequestException(string message)
            : base(message)
        {
        }

        public ApiRequestException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public ApiRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiRequestException(string message, int errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public ApiRequestException(string message, int errorCode, ResponseParameters parameters)
            : base(message)
        {
            ErrorCode = errorCode;
            Parameters = parameters;
        }

        public ApiRequestException(string message, int errorCode, ResponseParameters parameters,
                                   Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            Parameters = parameters;
        }
    }
}
