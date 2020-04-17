using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Exceptions
{
    public abstract class ForbiddenException : ApiRequestException
    {
        public override int ErrorCode => ForbiddenErrorCode;
        public const int ForbiddenErrorCode = 403;
        public const string ForbiddenErrorDescription = "Forbidden: ";

        protected ForbiddenException(string message)
            : base(message, ForbiddenErrorCode)
        {
        }

        protected ForbiddenException(string message, Exception innerException)
            : base(message, ForbiddenErrorCode, innerException)
        {
        }

        protected ForbiddenException(string message, ResponseParameters parameters)
            : base(message, ForbiddenErrorCode, parameters)
        {
        }

        protected ForbiddenException(string message, ResponseParameters parameters, Exception innerException)
            : base(message, ForbiddenErrorCode, parameters, innerException)
        {
        }
    }
}
