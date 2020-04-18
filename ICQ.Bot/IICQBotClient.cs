using ICQ.Bot.Args;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.InputFiles;
using ICQ.Bot.Types.ReplyMarkups;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using File = ICQ.Bot.Types.File;

namespace ICQ.Bot
{
    /// <summary>
    /// A client interface to use the ICQ Bot API
    /// https://icq.com/botapi/
    /// </summary>
    public interface IICQBotClient
    {
        TimeSpan Timeout { get; set; }
        bool IsReceiving { get; }
        int MessageOffset { get; set; }

        event EventHandler<ApiRequestEventArgs> MakingApiRequest;
        event EventHandler<ApiResponseEventArgs> ApiResponseReceived;
        event EventHandler<UpdateEventArgs> OnUpdate;
        event EventHandler<MessageEventArgs> OnMessage;
        event EventHandler<MessageEventArgs> OnMessageEdited;
        event EventHandler<CallbackQueryEventArgs> OnCallbackQuery;
        event EventHandler<ReceiveErrorEventArgs> OnReceiveError;
        event EventHandler<ReceiveGeneralErrorEventArgs> OnReceiveGeneralError;

        Task<bool> TestApiAsync(CancellationToken cancellationToken = default);
        void StartReceiving(UpdateType[] allowedUpdates = null, CancellationToken cancellationToken = default);
        void StopReceiving();

        /// <see href="https://icq.com/botapi/#/events/get_events_get"/>
        Task<Updates> GetUpdatesAsync(int offset = default,
            int limit = default,
            int timeout = default,
            IEnumerable<UpdateType> allowedUpdates = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/self/get_self_get"/>
        Task<User> GetMeAsync(CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/messages/get_messages_sendText"/>
        Task<MessagesResponse> SendTextMessageAsync(
            ChatId chatId,
            string text,
            ParseMode parseMode = default,
            bool disableWebPagePreview = default,
            bool disableNotification = default,
            int replyToMessageId = default,
            IReplyMarkup replyMarkup = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/messages/get_messages_editText"/>
        Task<MessagesResponse> EditMessageTextAsync(
            ChatId chatId,
            int messageId,
            string text,
            ParseMode parseMode = default,
            bool disableWebPagePreview = default,
            InlineKeyboardMarkup replyMarkup = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/messages/get_messages_sendFile"/>
        Task<MessagesResponse> SendFileAsync(
            ChatId chatId,
            InputOnlineFile document,
            string caption = default,
            ParseMode parseMode = default,
            bool disableNotification = default,
            int replyToMessageId = default,
            IReplyMarkup replyMarkup = default,
            InputMedia thumb = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/chats/get_chats_blockUser"/>
        Task KickChatMemberAsync(
            ChatId chatId,
            int userId,
            DateTime untilDate = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/messages/get_messages_answerCallbackQuery"/>
        Task AnswerCallbackQueryAsync(
            string callbackQueryId,
            string text = default,
            bool showAlert = default,
            string url = default,
            int cacheTime = default,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/messages/get_messages_deleteMessages"/>
        Task DeleteMessagesAsync(
            ChatId chatId,
            IEnumerable<int> messageIds,
            CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/chats/get_chats_sendActions"/>
        Task SendChatActionsAsync(ChatId chatId, ChatAction chatAction, CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/files/get_files_getInfo"/>
        Task<Types.File> GetFileInfoAsync(string fileId, CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/chats/get_chats_unblockUser"/>
        Task UnbanChatMemberAsync(ChatId chatId, int userId, CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/chats/get_chats_getInfo"/>
        Task<ChatInfo> GetChatAsync(ChatId chatId, CancellationToken cancellationToken = default);

        /// <see href="https://icq.com/botapi/#/chats/get_chats_getAdmins"/>
        Task<ChatAdmins> GetChatAdministratorsAsync(ChatId chatId, CancellationToken cancellationToken = default);
    }
}
