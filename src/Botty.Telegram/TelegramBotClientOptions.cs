using System;

namespace Botty.Telegram
{
    /// <summary>
    /// Settings for Telegram client
    /// </summary>
    public class TelegramBotClientOptions
    {
        private const string BaseTelegramUrl = "https://api.telegram.org";

        /// <summary>
        /// API token
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Base telegram API URL
        /// </summary>
        public string BaseUrl { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token">API token</param>
        /// <param name="baseUrl">Base telegram API URL</param>
        public TelegramBotClientOptions(string token, string? baseUrl = default)
        {
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));

            Token = token;
            BaseUrl = baseUrl ?? BaseTelegramUrl;
        }
    }
}
