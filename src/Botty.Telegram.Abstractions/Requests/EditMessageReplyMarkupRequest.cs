using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for editing message reply markup
    /// </summary>
    public class EditMessageReplyMarkupRequest
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
        /// Inline keyboard
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        /// <param name="inlineKeyboard">Inline keyboard</param>
        public EditMessageReplyMarkupRequest(string chatId, long messageId, InlineKeyboardMarkup inlineKeyboard)
        {
            ChatId = chatId;
            MessageId = messageId;
            ReplyMarkup = inlineKeyboard;
        }
    }
}
