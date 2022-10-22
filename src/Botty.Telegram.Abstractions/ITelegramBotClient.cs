using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Botty.Telegram.Abstractions
{
    /// <summary>
    /// Client for Telegram Bot API
    /// </summary>
    public interface ITelegramBotClient
    {
        /// <summary>
        /// Sends request to Telegram Bot API without body
        /// </summary>
        /// <typeparam name="TResponse">Type of request response</typeparam>
        /// <param name="method">Telegram API method name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Telegram API request response</returns>
        Task<TResponse> SendRequestAsync<TResponse>(string method, CancellationToken cancellationToken);

        /// <summary>
        /// Sends request to Telegram Bot API with body in json
        /// </summary>
        /// <typeparam name="TResponse">Type of request response</typeparam>
        /// <param name="method">Telegram API method name</param>
        /// <param name="content">Request object</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Telegram API request response</returns>
        Task<TResponse> SendRequestAsync<TResponse>(string method, object content, CancellationToken cancellationToken);

        /// <summary>
        /// Sends request to Telegram Bot API with body in form data
        /// </summary>
        /// <typeparam name="TResponse">Type of request response</typeparam>
        /// <param name="method">Telegram API method name</param>
        /// <param name="formData">Multipart ford data content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Telegram API request response</returns>
        Task<TResponse> SendMultipartFormDataAsync<TResponse>(string method, MultipartFormDataContent formData, CancellationToken cancellationToken);
    }
}