namespace ICQ.Bot.Exceptions
{
    public class ChatNotFoundException : BadRequestException
    {
        public ChatNotFoundException(string message)
            : base(message)
        {
        }
    }
}