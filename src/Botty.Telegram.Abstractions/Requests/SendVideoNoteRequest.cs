using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending video note
    /// </summary>
    public class SendVideoNoteRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Video note to send
        /// </summary>
        public InputFile VideoNote { get; }

        /// <summary>
        /// Duration of sent video in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Video width and height, i.e. diameter of the video message
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Thumbnail of the file sent
        /// </summary>
        public InputFile? Thumb { get; set; }

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
        /// <param name="videoNote">Video note</param>
        public SendVideoNoteRequest(string chatId, InputFile videoNote)
        {
            ChatId = chatId;
            VideoNote = videoNote;
        }
    }
}
