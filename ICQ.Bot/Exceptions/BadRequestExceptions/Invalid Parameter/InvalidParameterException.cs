namespace ICQ.Bot.Exceptions
{
    public class InvalidParameterException : BadRequestException
    {
        internal const string ParamGroupName = "param";

        public string Parameter { get; }

        public InvalidParameterException(string paramName, string message)
            : base(message)
        {
            Parameter = paramName;
        }

        public InvalidParameterException(string paramName)
            : base(paramName)
        {
            Parameter = paramName;
        }
    }
}
