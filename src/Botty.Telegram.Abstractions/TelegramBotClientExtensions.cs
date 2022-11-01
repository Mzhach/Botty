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

        /// <summary>
        /// Deletes a message, including service messages, with the following limitations:
        /// <list type="bullet"> 
        ///     <item> A message can only be deleted if it was sent less than 48 hours ago. </item>
        ///     <item> A dice message in a private chat can only be deleted if it was sent more than 24 hours ago. </item>
        ///     <item> Bots can delete outgoing messages in private chats, groups, and supergroups. </item>
        ///     <item> Bots can delete incoming messages in private chats. </item>
        ///     <item> Bots granted can_post_messages permissions can delete outgoing messages in channels. </item>
        ///     <item> If the bot is an administrator of a group, it can delete any message there. </item>
        ///     <item> If the bot has can_delete_messages permission in a supergroup or a channel, it can delete any message there. </item>
        /// </list>
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if success</returns>
        public static Task<bool> DeleteMessageAsync(
            this ITelegramBotClient telegramBotClient,
            DeleteMessageRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<bool>("deleteMessage", request, cancellationToken);
        }

        /// <summary>
        /// Edits message text
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Edited message</returns>
        public static Task<Message> EditMessageTextAsync(
            this ITelegramBotClient telegramBotClient,
            EditMessageTextRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("editMessageText", request, cancellationToken);
        }

        /// <summary>
        /// Edits message reply markup
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Edited message</returns>
        public static Task<Message> EditMessageReplyMarkupAsync(
            this ITelegramBotClient telegramBotClient,
            EditMessageReplyMarkupRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("editMessageReplyMarkup", request, cancellationToken);
        }

        /// <summary>
        /// Forwards message of any kind. Service messages can't be forwarded
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Forwarded message</returns>
        public static Task<Message> ForwardMessageAsync(
            this ITelegramBotClient telegramBotClient,
            ForwardMessageRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("forwardMessage", request, cancellationToken);
        }

        /// <summary>
        /// Sends pool
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Sent poll message</returns>
        public static Task<Message> SendPollAsync(
            this ITelegramBotClient telegramBotClient,
            SendPollRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("sendPoll", request, cancellationToken);
        }

        /// <summary>
        /// Sends dice
        /// </summary>
        /// <param name="telegramBotClient">Telegram Bot API client</param>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Sent dice message</returns>
        public static Task<Message> SendDiceAsync(
            this ITelegramBotClient telegramBotClient,
            SendDiceRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            return telegramBotClient.SendRequestAsync<Message>("sendDice", request, cancellationToken);
        }
    }
}
