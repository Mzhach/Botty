using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for stopping live location
    /// </summary>
    public class StopMessageLiveLocationRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Identifier of the message to edit
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// New inline keyboard
        /// </summary>
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        public StopMessageLiveLocationRequest(string chatId, long messageId)
        {
            ChatId = chatId;
            MessageId = messageId;
        }
    }
}
