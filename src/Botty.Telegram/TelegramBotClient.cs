using Botty.Telegram.Abstractions;
using Botty.Telegram.Abstractions.Exceptions;
using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Serialization;
using System;
using System.Net;
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

        private Task<TResponse> SendRequestAsync<TResponse>(string method, CancellationToken cancellationToken)
            where TResponse : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        private Task<TResponse> SendRequestAsync<TResponse>(string method, object content, CancellationToken cancellationToken)
            where TResponse : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            var serializedContent = JsonSerializer.Serialize(content, SerializerOptions.Telegram);
            request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            return SendRequestAsync<TResponse>(request, cancellationToken);
        }
        private Uri BuildUri(string method) => new Uri($"{_options.BaseUrl}/bot{_options.Token}/{method}");

        private async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
            where TResponse : class
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
                var response = JsonSerializer.Deserialize<Response<TResponse>>(contentStream, SerializerOptions.Telegram);

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
