using System;

namespace ICQ.Bot.Exceptions
{
    public class FileIdNotFoundException : BadRequestException
    {
        public FileIdNotFoundException()
            : base("missing file id")
        {
        }

        public FileIdNotFoundException(string message)
            : base(message)
        {
        }

        public FileIdNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}