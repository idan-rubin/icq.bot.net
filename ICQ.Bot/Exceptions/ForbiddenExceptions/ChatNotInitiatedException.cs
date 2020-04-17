namespace ICQ.Bot.Exceptions
{
    public class ChatNotInitiatedException : ForbiddenException
    {
        public ChatNotInitiatedException(string message) : base(message)
        {
        }
    }
}
