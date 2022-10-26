using Botty.Telegram.Abstractions;
using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Botty.Telegram
{
    /// <summary>
    /// Extensions for Telegram Bot API client
    /// </summary>
    public static class TelegramBotClientExtensions
    {
        /// <summary>
        /// Returns basic information about the bot
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Bot basic information</returns>
        public static Task<User> GetMeAsync(
            this ITelegramBotClient telegramBotClient,
            CancellationToken cancellationToken = default)
            => telegramBotClient.SendRequestAsync<User>("getMe", cancellationToken);

        /// <summary>
        /// Receive incoming updates
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Update</returns>
        public static Task<Update[]> GetUpdatesAsync(
            this ITelegramBotClient telegramBotClient,
            GetUpdatesRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Update[]>("getUpdates", request, cancellationToken);
        }

        /// <summary>
        /// Set webhook integration
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True on success</returns>
        public static Task<bool> SetWebhookAsync(
            this ITelegramBotClient telegramBotClient,
            SetWebhookRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendMultipartFormDataAsync<bool>("setWebhook", request, cancellationToken);
        }

        /// <summary>
        /// Delete webhook integration
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True on success</returns>
        public static Task<bool> DeleteWebhookAsync(
            this ITelegramBotClient telegramBotClient,
            DeleteWebhookRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<bool>("deleteWebhook", request, cancellationToken);
        }

        /// <summary>
        /// Get webhook info
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Current status of a webhook</returns>
        public static Task<WebhookInfo> GetWebhookInfoAsync(
            this ITelegramBotClient telegramBotClient,
            CancellationToken cancellationToken = default)
            => telegramBotClient.SendRequestAsync<WebhookInfo>("getWebhookInfo", cancellationToken);

        /// <summary>
        /// Send text message
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Sent message</returns>
        public static Task<Message> SendMessageAsync(
            this ITelegramBotClient telegramBotClient,
            SendMessageRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("sendMessage", request, cancellationToken);
        }
    }
}
