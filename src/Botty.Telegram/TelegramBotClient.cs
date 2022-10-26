using Botty.Telegram.Abstractions;
using Botty.Telegram.Abstractions.Exceptions;
using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Converters.MultipartFormData;
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
        protected readonly TelegramBotClientOptions Options;
        protected readonly HttpClient HttpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Telegram client options</param>
        public TelegramBotClient(TelegramBotClientOptions options, HttpClient httpClient)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public virtual Task<TResponse> SendRequestAsync<TResponse>(string method, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task<TResponse> SendRequestAsync<TResponse>(string method, object content, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            var serializedContent = TelegramBotClientSerializer.Serialize(content);
            request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task<TResponse> SendMultipartFormDataAsync<TResponse>(string method, object content, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(method));
            request.Content = MultipartFormDataConverter.Convert(content);

            return SendRequestAsync<TResponse>(request, cancellationToken);
        }

        protected virtual Uri BuildUri(string method) => new Uri($"{Options.BaseUrl}/bot{Options.Token}/{method}");

        protected virtual async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                using var httpResponse = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

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
