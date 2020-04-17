using System;
using System.Linq;
using System.Text.RegularExpressions;
using ICQ.Bot.Types;

namespace ICQ.Bot.Exceptions
{
    internal static class ApiExceptionParser
    {
        private static readonly IApiExceptionInfo<ApiRequestException>[] ExceptionInfos = {
            new BadRequestExceptionInfo<ChatNotFoundException>("chat not found"),
            new BadRequestExceptionInfo<UserNotFoundException>("user not found"),
            new BadRequestExceptionInfo<InvalidUserIdException>("USER_ID_INVALID"),

            new ForbiddenExceptionInfo<ChatNotInitiatedException>("bot can't initiate conversation with a user"),

            new BadRequestExceptionInfo<InvalidParameterException>($@"\w{{3,}} Request: invalid (?<{InvalidParameterException.ParamGroupName}>[\w|\s]+)$"),
            new BadRequestExceptionInfo<InvalidParameterException>($@"\w{{3,}} Request: (?<{InvalidParameterException.ParamGroupName}>[\w|\s]+) invalid$"),

            new BadRequestExceptionInfo<MessageIsNotModifiedException>("message is not modified"),
        };

        private static string TruncateBadRequestErrorDescription(string message) =>
            TryTruncateErrorDescription(message, BadRequestException.BadRequestErrorDescription);

        private static string TruncateForbiddenErrorDescription(string message) =>
            TryTruncateErrorDescription(message, ForbiddenException.ForbiddenErrorDescription);

        private static string TryTruncateErrorDescription(string message, string description)
        {
            bool hasErrorTypeDescription = message?.IndexOf(description) == 0;
            if (hasErrorTypeDescription)
                message = message.Substring(description.Length);
            return message;
        }
    }
}
