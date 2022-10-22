using Botty.Telegram.Abstractions;
using Botty.Telegram.Abstractions.Exceptions;
using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Extensions;
using Botty.Telegram.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Botty.Telegram
{
    /// <summary>
    /// Client implementation for Telegram Bot API
    /// </summary>
    public class TelegramBotClient : ITelegramBotClient
    {
        private readonly TelegramBotClientOptions _options;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Telegram client options</param>
        public TelegramBotClient(TelegramBotClientOptions options, HttpClient httpClient)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public Task<User> GetMeAsync(CancellationToken cancellationToken = default) => SendRequestAsync<User>("getMe", cancellationToken);

        /// <inheritdoc />
        public Task<Update[]> GetUpdatesAsync(GetUpdatesRequest request, CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return SendRequestAsync<Update[]>("getUpdates", request, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Message> SendMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return SendRequestAsync<Message>("sendMessage", request, cancellationToken);
        }

        /// <inheritdoc />
        public Task<bool> SetWebhookAsync(SetWebhookRequest request, CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(request.Url), nameof(request.Url).ToSnakeCase());

            if (request.Certificate != null)
            {
                formData.Add(
                    new StreamContent(request.Certificate.FileContent),
                    nameof(request.Certificate).ToSnakeCase(),
                    request.Certificate.Filename);
            }

            if (!string.IsNullOrEmpty(request.IpAddress))
                formData.Add(new StringContent(request.IpAddress), nameof(request.IpAddress).ToSnakeCase());

            if (request.MaxConnections.HasValue)
                formData.Add(new StringContent(request.MaxConnections.Value.ToString()), nameof(request.MaxConnections).ToSnakeCase());

            if (request.AllowedUpdates.IsNotEmpty())
            {
                foreach(var update in request.AllowedUpdates!)
                    formData.Add(new StringContent(update.ToString().ToSnakeCase()), nameof(request.AllowedUpdates).ToSnakeCase());
            }

            if (request.DropPendingUpdates.HasValue)
                formData.Add(new StringContent(request.DropPendingUpdates.ToString()), nameof(request.DropPendingUpdates).ToSnakeCase());

            if (!string.IsNullOrEmpty(request.SecretToken))
                formData.Add(new StringContent(request.SecretToken), nameof(request.SecretToken).ToSnakeCase());

            return SendFormAsync<bool>("setWebhook", formData, cancellationToken);
        }

        /// <inheritdoc />
        public Task<bool> DeleteWebhookAsync(DeleteWebhookRequest request, CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return SendRequestAsync<bool>("deleteWebhook", request, cancellationToken);
        }

        /// <inheritdoc />
        public Task<WebhookInfo> GetWebhookInfoAsync(CancellationToken cancellationToken = default) => SendRequestAsync<WebhookInfo>("getWebhookInfo", cancellationToken);

        private Task<TResponse> SendRequestAsync<TResponse>(string method, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        private Task<TResponse> SendRequestAsync<TResponse>(string method, object content, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            var serializedContent = TelegramBotClientSerializer.Serialize(content);
            request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        private Task<TResponse> SendFormAsync<TResponse>(string method, MultipartFormDataContent formData, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            request.Content = formData;

            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        private Uri BuildUri(string method) => new Uri($"{_options.BaseUrl}/bot{_options.Token}/{method}");

        private async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                using var httpResponse = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if ((int)httpResponse.StatusCode >= 500)
                {
                    var errorContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new TelegramBotClientException($"An error has occured while sending the request. StatusCode: {httpResponse.StatusCode}, Content: {errorContent}");
                }

                var contentStream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                var response = TelegramBotClientSerializer.Deserialize<Response<TResponse>>(contentStream);

                if (response is null) 
                    throw new TelegramBotClientException("Serializer couldn't deserialize response's content to object");

                if (!response.Ok) 
                    throw new TelegramBotClientException($"Telegram API returned an error. ErrorCode: {response.ErrorCode} Description: {response.Description}");

                return response.Result!;
            }
            catch (HttpRequestException ex)
            {
                throw new TelegramBotClientException("An error has occured while sending the request", ex);
            }
            catch (JsonException ex)
            {
                throw new TelegramBotClientException("An error has occured while deserialization the request's content", ex);
            }
        }
    }
}
