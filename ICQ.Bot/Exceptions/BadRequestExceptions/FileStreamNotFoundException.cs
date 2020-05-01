using System;

namespace ICQ.Bot.Exceptions
{
    public class FileStreamNotFoundException : BadRequestException
    {
        public FileStreamNotFoundException()
            : base("missing file stream")
        {
        }

        public FileStreamNotFoundException(string message)
            : base(message)
        {
        }

        public FileStreamNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}