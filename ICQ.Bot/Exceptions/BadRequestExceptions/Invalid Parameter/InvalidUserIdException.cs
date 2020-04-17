namespace ICQ.Bot.Exceptions
{
    public class InvalidUserIdException : InvalidParameterException
    {
        public InvalidUserIdException(string message)
            : base("userId", message)
        {
        }
    }
}