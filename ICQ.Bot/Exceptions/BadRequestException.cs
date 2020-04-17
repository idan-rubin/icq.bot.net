using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Exceptions
{
    public abstract class BadRequestException : ApiRequestException
    {
        public override int ErrorCode => BadRequestErrorCode;
        public const int BadRequestErrorCode = 400;
        public const string BadRequestErrorDescription = "Bad Request: ";
        protected BadRequestException(string message)
            : base(message, BadRequestErrorCode)
        {
        }

        protected BadRequestException(string message, Exception innerException)
            : base(message, BadRequestErrorCode, innerException)
        {
        }

        protected BadRequestException(string message, ResponseParameters parameters)
            : base(message, BadRequestErrorCode, parameters)
        {
        }

        protected BadRequestException(string message, ResponseParameters parameters, Exception innerException)
            : base(message, BadRequestErrorCode, parameters, innerException)
        {
        }
    }
}
