using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for editing message text
    /// </summary>
    public class EditMessageTextRequest
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
        /// New text of the message, 1-4096 characters after entities parsing
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Mode for parsing entities in the message text
        /// </summary>
        public ParseMode? ParseMode { get; set; }

        /// <summary>
        /// A JSON-serialized list of special entities that appear in message text, which can be specified instead of parse_mode
        /// </summary>
        public MessageEntity[]? Entities { get; set; }

        /// <summary>
        /// Disables link previews for links in this message
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// Inline keyboard
        /// </summary>
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        /// <param name="text">Text message</param>
        public EditMessageTextRequest(string chatId, long messageId, string text)
        {
            ChatId = chatId;
            MessageId = messageId;
            Text = text;
        }
    }
}
