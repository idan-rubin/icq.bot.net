using ICQ.Bot.Args;
using ICQ.Bot.Converters;
using ICQ.Bot.Exceptions;
using ICQ.Bot.Requests;
using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.Enums;
using ICQ.Bot.Types.InputFiles;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ICQ.Bot
{
    //https://stackoverflow.com/questions/3526701/how-to-generate-a-class-from-an-interface
    //https://icq.com/botapi/#/files/get_files_getInfo
    public class ICQBotClient : IICQBotClient
    {

        private static readonly Updates EmptyUpdates = new Updates();

        private const string baseUrl = "https://api.icq.net/bot/v1";

        private const string baseFileUrl = "https://files.icq.net/get";

        private readonly string _token;

        private readonly HttpClient _httpClient;

        public TimeSpan Timeout
        {
            get => _httpClient.Timeout;
            set => _httpClient.Timeout = value;
        }

        public bool IsReceiving { get; set; }

        private CancellationTokenSource _receivingCancellationTokenSource;
        public int MessageOffset { get; set; }

        public ICQBotClient(string token, HttpClient httpClient = null)
        {
            _token = token;
            _httpClient = httpClient ?? new HttpClient();
        }

        public ICQBotClient(string token, IWebProxy webProxy)
        {
            _token = token;
            var httpClientHander = new HttpClientHandler
            {
                Proxy = webProxy,
                UseProxy = true
            };
            _httpClient = new HttpClient(httpClientHander);
        }

        public event EventHandler<ApiRequestEventArgs> MakingApiRequest;
        public event EventHandler<ApiResponseEventArgs> ApiResponseReceived;
        public event EventHandler<UpdateEventArgs> OnUpdate;
        public event EventHandler<MessageEventArgs> OnMessage;
        public event EventHandler<MessageEventArgs> OnMessageEdited;
        public event EventHandler<CallbackQueryEventArgs> OnCallbackQuery;
        public event EventHandler<ReceiveErrorEventArgs> OnReceiveError;
        public event EventHandler<ReceiveGeneralErrorEventArgs> OnReceiveGeneralError;

        public Task AnswerCallbackQueryAsync(
            string callbackQueryId,
            string text = default,
            bool showAlert = default,
            string url = default,
            int cacheTime = default,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new AnswerCallbackQueryRequest(callbackQueryId)
            {
                Text = text,
                ShowAlert = showAlert,
                Url = url,
                CacheTime = cacheTime
            }, cancellationToken);

        public Task DeleteMessagesAsync(ChatId chatId, int messageId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MessagesResponse> EditMessageTextAsync(
            ChatId chatId,
            int messageId,
            string text,
            ParseMode parseMode = default,
            bool disableWebPagePreview = default,
            InlineKeyboardMarkup replyMarkup = default,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new EditMessageTextRequest(chatId, messageId, text)
            {
                ParseMode = parseMode,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        public Task<ChatMember[]> GetChatAdministratorsAsync(
            ChatId chatId,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new GetChatAdministratorsRequest(chatId), cancellationToken);

        public Task<Chat> GetChatAsync(
            ChatId chatId,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new GetChatRequest(chatId), cancellationToken);

        public Task<int> GetChatMembersCountAsync(
                    ChatId chatId,
                    CancellationToken cancellationToken = default
                ) =>
                    MakeRequestAsync(new GetChatMembersCountRequest(chatId), cancellationToken);

        public Task<Types.File> GetFileAsync(
            string fileId,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new GetFileRequest(fileId), cancellationToken);

        public async Task<Types.File> GetInfoAndDownloadFileAsync(
            string fileId,
            Stream destination,
            CancellationToken cancellationToken = default
        )
        {
            var file = await GetFileAsync(fileId, cancellationToken)
                .ConfigureAwait(false);

            await DownloadFileAsync(file.FilePath, destination, cancellationToken)
                .ConfigureAwait(false);

            return file;
        }

        public async Task DownloadFileAsync(
            string filePath,
            Stream destination,
            CancellationToken cancellationToken = default
        )
        {
            if (string.IsNullOrWhiteSpace(filePath) || filePath.Length < 2)
            {
                throw new ArgumentException("Invalid file path", nameof(filePath));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var fileUri = new Uri($"{baseFileUrl}{_token}/{filePath}");

            var response = await _httpClient
                .GetAsync(fileUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using (response)
            {
                await response.Content.CopyToAsync(destination)
                    .ConfigureAwait(false);
            }
        }

        public Task<User> GetMeAsync(CancellationToken cancellationToken = default)
                    => MakeRequestAsync(new GetMeRequest(), cancellationToken);

        public Task<Updates> GetUpdatesAsync(
            int offset = default,
            int limit = default,
            int timeout = default,
            IEnumerable<UpdateType> allowedUpdates = default,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new GetUpdatesRequest(offset, timeout), cancellationToken);

        public Task KickChatMemberAsync(
            ChatId chatId,
            int userId,
            DateTime untilDate = default,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new KickChatMemberRequest(chatId, userId)
            {
                UntilDate = untilDate
            }, cancellationToken);

        public async Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            string url = string.Format("{0}{1}", baseUrl, request.MethodName);
            var httpRequest = new HttpRequestMessage(request.Method, url)
            {
                Content = request.ToHttpContent()
            };

            var reqDataArgs = new ApiRequestEventArgs
            {
                MethodName = request.MethodName,
                HttpContent = httpRequest.Content,
            };
            MakingApiRequest?.Invoke(this, reqDataArgs);

            HttpResponseMessage httpResponse;
            try
            {
                if (request.Method == HttpMethod.Get)
                {
                    if (!string.IsNullOrWhiteSpace(request.QueryString))
                    {
                        var queryString = request.QueryString.Replace("?", String.Empty);
                        queryString = string.Format("?token={0}&{1}", _token, queryString);
                        url = string.Format("{0}{1}", url, queryString);
                    }
                    else
                    {
                        url = string.Format("?token={0}", _token);
                    }

                    httpResponse = await _httpClient.GetAsync(url).ConfigureAwait(false);
                }
                else if (request.Method == HttpMethod.Post)
                {
                    request.Parameters.Add("token", _token);
                    var encodedContent = new FormUrlEncodedContent(request.Parameters);
                    httpResponse = await _httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);
                }
                else
                {
                    throw new ApiRequestException(string.Format("invalid request method: {0}", request.Method.Method));
                }
            }
            catch (TaskCanceledException e)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;

                throw new ApiRequestException("request timed out", 408, e);
            }

            // required since user might be able to set new status code using following event arg
            var actualResponseStatusCode = httpResponse.StatusCode;
            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            ApiResponseReceived?.Invoke(this, new ApiResponseEventArgs
            {
                ResponseMessage = httpResponse,
                ApiRequestEventArgs = reqDataArgs
            });

            switch (actualResponseStatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.BadRequest when !string.IsNullOrWhiteSpace(responseJson):
                case HttpStatusCode.Forbidden when !string.IsNullOrWhiteSpace(responseJson):
                case HttpStatusCode.Conflict when !string.IsNullOrWhiteSpace(responseJson):
                    // Do NOT throw here, an ApiRequestException will be thrown next
                    break;
                default:
                    httpResponse.EnsureSuccessStatusCode();
                    break;
            }

            var apiResponse = JsonConvert.DeserializeObject<TResponse>(responseJson, new DateTimeConverter());
            if (apiResponse == null)
            {
                string text = string.Format("response failed to be parsed");
                throw new ApiRequestException(text);
            }


            return apiResponse;
        }

        public Task SendChatActionAsync(
            ChatId chatId,
            ChatAction chatAction,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new SendChatActionRequest(chatId, chatAction), cancellationToken);

        public Task<MessagesResponse> SendFileAsync(
            ChatId chatId,
            InputOnlineFile document,
            string caption = default,
            ParseMode parseMode = default,
            bool disableNotification = default,
            int replyToMessageId = default,
            IReplyMarkup replyMarkup = default,
            InputMedia thumb = default,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new SendDocumentRequest(chatId, document, caption)
            {
                Thumb = thumb,
                ParseMode = parseMode,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        public Task<MessagesResponse> SendTextMessageAsync(
        ChatId chatId,
        string text,
        ParseMode parseMode = default,
        bool disableWebPagePreview = default,
        bool disableNotification = default,
        int replyToMessageId = default,
        IReplyMarkup replyMarkup = default,
        CancellationToken cancellationToken = default
    ) =>
        MakeRequestAsync(new SendMessageRequest(chatId, text)
        {
            ParseMode = parseMode,
            DisableWebPagePreview = disableWebPagePreview,
            DisableNotification = disableNotification,
            ReplyToMessageId = replyToMessageId,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

        public Task SetChatPermissionsAsync(
            ChatId chatId,
            ChatPermissions permissions,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new SetChatPermissionsRequest(chatId, permissions), cancellationToken);

        public void StartReceiving(UpdateType[] allowedUpdates = null, CancellationToken cancellationToken = default)
        {
            _receivingCancellationTokenSource = new CancellationTokenSource();

            cancellationToken.Register(() => _receivingCancellationTokenSource.Cancel());

            ReceiveAsync(allowedUpdates, _receivingCancellationTokenSource.Token);
        }

        private async void ReceiveAsync(
           UpdateType[] allowedUpdates,
           CancellationToken cancellationToken = default)
        {
            IsReceiving = true;
            while (!cancellationToken.IsCancellationRequested)
            {
                var timeout = Convert.ToInt32(Timeout.TotalSeconds);
                var updates = EmptyUpdates;

                try
                {
                    updates = await GetUpdatesAsync(
                        MessageOffset,
                        timeout: timeout,
                        allowedUpdates: allowedUpdates,
                        cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                }
                catch (ApiRequestException apiException)
                {
                    OnReceiveError?.Invoke(this, apiException);
                }
                catch (Exception generalException)
                {
                    OnReceiveGeneralError?.Invoke(this, generalException);
                }

                try
                {
                    if (updates.Events != null)
                    {
                        foreach (var update in updates.Events)
                        {
                            OnUpdateReceived(new UpdateEventArgs(update));
                            MessageOffset = update.EventId + 1;
                        }
                    }
                }
                catch
                {
                    IsReceiving = false;
                    throw;
                }
            }

            IsReceiving = false;
        }

        protected virtual void OnUpdateReceived(UpdateEventArgs e)
        {
            OnUpdate?.Invoke(this, e);

            switch (e.Update.Type)
            {
                case "newMessage":
                    OnMessage?.Invoke(this, e);
                    break;

                case "callbackQuery":
                    OnCallbackQuery?.Invoke(this, e);
                    break;

                case "editedMessage":
                    OnMessageEdited?.Invoke(this, e);
                    break;
            }
        }

        public void StopReceiving()
        {
            try
            {
                _receivingCancellationTokenSource.Cancel();
            }
            catch (WebException)
            {
            }
            catch (TaskCanceledException)
            {
            }
        }

        public async Task<bool> TestApiAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await GetMeAsync(cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch (ApiRequestException e)
                when (e.ErrorCode == 401)
            {
                return false;
            }
        }

        public Task UnbanChatMemberAsync(
            ChatId chatId,
            int userId,
            CancellationToken cancellationToken = default
        ) =>
            MakeRequestAsync(new UnbanChatMemberRequest(chatId, userId), cancellationToken);
    }
}
