namespace ICQ.Bot.Exceptions
{
    public class InvalidGameShortNameException : InvalidParameterException
    {
        public InvalidGameShortNameException(string message)
            : base("game_short_name", message)
        {
        }
    }
}