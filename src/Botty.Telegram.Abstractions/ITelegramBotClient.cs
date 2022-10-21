using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
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
        /// Returns basic information about the bot
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Bot basic information</returns>
        public Task<User> GetMeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Receive incoming updates
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Update</returns>
        public Task<Update[]> GetUpdatesAsync(GetUpdatesRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set webhook integration
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True on success</returns>
        public Task<bool> SetWebhookAsync(SetWebhookRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete webhook integration
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True on success</returns>
        public Task<bool> DeleteWebhookAsync(DeleteWebhookRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get webhook info
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Current status of a webhook</returns>
        public Task<WebhookInfo> GetWebhookInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Send text message
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Sent message</returns>
        public Task<Message> SendMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default);
    }
}