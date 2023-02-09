using Botty.Telegram.Abstractions;
using Botty.Telegram.Abstractions.Exceptions;
using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Converters.MultipartFormData;
using Botty.Telegram.Serializers.Json;
using System;
using System.IO;
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
            var serializedContent = TelegramBotClientJsonSerializer.Serialize(content);
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

        /// <inheritdoc />
        public async Task<Stream> DownloadFileAsync(string filePath, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

            var request = new HttpRequestMessage(HttpMethod.Get, BuildFileUri(filePath));
            var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Builds URL to Telegram Bot API method
        /// </summary>
        /// <param name="method">Telegram Bot API method</param>
        /// <returns>Absolute URL</returns>
        protected virtual Uri BuildUri(string method) => new Uri($"{Options.BaseUrl}/bot{Options.Token}/{method}");

        /// <summary>
        /// Builds URL for downloading files from Telegram Bot API
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected virtual Uri BuildFileUri(string filePath) => new Uri($"{Options.BaseUrl}/file/bot{Options.Token}/{filePath}");

        /// <summary>
        /// Sends request to Telegram Bot API and parses response
        /// </summary>
        /// <typeparam name="TResponse">Type of response</typeparam>
        /// <param name="request">HTTP request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Telegram Bot API request's result</returns>
        protected virtual async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var httpResponse = await SendRequestAsync(request, cancellationToken);
            var contentStream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);

            Response<TResponse> response;
            try
            {
                response = TelegramBotClientJsonSerializer.Deserialize<Response<TResponse>>(contentStream);
            }
            catch (JsonException ex)
            {
                throw new TelegramBotClientException("An error has occured while deserialization the request's content", ex);
            }

            if (response is null)
                throw new TelegramBotClientException("Serializer couldn't deserialize response's content to object");

            if (!response.Ok)
                throw new TelegramBotClientException($"Telegram API returned an error. ErrorCode: {response.ErrorCode} Description: {response.Description}");

            return response.Result!;
        }

        /// <summary>
        /// Sends HTTP request to Telegram Bot API
        /// </summary>
        /// <param name="request">HTTP request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HTTP response</returns>
        protected virtual async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var httpResponse = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if ((int)httpResponse.StatusCode >= 500)
                {
                    var errorContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new TelegramBotClientException($"An error has occured while sending the request. StatusCode: {httpResponse.StatusCode}, Content: {errorContent}");
                }

                return httpResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new TelegramBotClientException("An error has occured while sending the request", ex);
            }
        }
    }
}
