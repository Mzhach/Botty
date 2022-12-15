using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for editing message media
    /// </summary>
    public class EditMessageMediaRequest
    {
        /// <summary>
        /// identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Identifier of the message to edit
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// New media content of the message
        /// </summary>
        public InputMedia Media { get; }

        /// <summary>
        /// New inline keyboard
        /// </summary>
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        /// <param name="media">New media content of the message</param>
        public EditMessageMediaRequest(string chatId, long messageId, InputMedia media)
        {
            ChatId = chatId;
            MessageId = messageId;
            Media = media;
        }
    }
}
