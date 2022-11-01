using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for stopping poll
    /// </summary>
    public class StopPollRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Identifier of the original message with the poll
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// Optional. Inline keyboard for a new message inline keyboard
        /// </summary>
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        public StopPollRequest(string chatId, long messageId)
        {
            ChatId = chatId;
            MessageId = messageId;
        }
    }
}
