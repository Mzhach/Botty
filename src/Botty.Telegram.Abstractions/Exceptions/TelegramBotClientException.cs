using System;

namespace Botty.Telegram.Abstractions.Exceptions
{
    /// <summary>
    /// Telegram Bot API Client exception
    /// </summary>
    public class TelegramBotClientException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        public TelegramBotClientException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception</param>
        public TelegramBotClientException(string message, Exception innerException) : base(message, innerException) { }
    }
}
