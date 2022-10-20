using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending text messages
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Text of the message to be sent
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Mode for parsing entities in the message text
        /// </summary>
        public ParseModeType? ParseMode { get; set; }

        /// <summary>
        /// A JSON-serialized list of special entities that appear in message text, which can be specified instead of parse_mode
        /// </summary>
        public MessageEntity[]? Entities { get; set; }

        /// <summary>
        /// Disables link previews for links in this message
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Protects the contents of the sent message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Pass True if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Additional interface options
        /// </summary>
        public IReplyMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="text">Message text</param>
        public SendMessageRequest(string chatId, string text)
        {
            ChatId = chatId;
            Text = text;
        }
    }
}