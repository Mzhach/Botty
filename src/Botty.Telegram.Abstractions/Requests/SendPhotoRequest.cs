using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending photo
    /// </summary>
    public class SendPhotoRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Photo to send
        /// </summary>
        public InputFile Photo { get; }

        /// <summary>
        /// Photo caption, 0-1024 characters after entities parsing
        /// </summary>
        public string? Caption { get; set; }

        /// <summary>
        /// Mode for parsing entities in the photo caption
        /// </summary>
        public ParseMode? ParseMode { get; set; }

        /// <summary>
        /// Special entities that appear in the caption
        /// </summary>
        public MessageEntity[]? CaptionEntities { get; set; }

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
        /// <param name="photo">Photo</param>
        public SendPhotoRequest(string chatId, InputFile photo)
        {
            ChatId = chatId;
            Photo = photo;
        }
    }
}
