using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending audio
    /// </summary>
    public class SendAudioRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Audio file to send.
        /// </summary>
        public InputFile Audio { get; }

        /// <summary>
        /// Audio caption, 0-1024 characters after entities parsing
        /// </summary>
        public string? Caption { get; set; }

        /// <summary>
        /// Mode for parsing entities in the document caption
        /// </summary>
        public ParseMode? ParseMode { get; set; }

        /// <summary>
        /// List of special entities that appear in the caption
        /// </summary>
        public MessageEntity[]? CaptionEntities { get; set; }

        /// <summary>
        /// Duration of the audio in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Performer
        /// </summary>
        public string? Performer { get; set; }

        /// <summary>
        /// Track name
        /// </summary>
        public string? Title { get; set; }

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
        /// <param name="audio">Audio</param>
        public SendAudioRequest(string chatId, InputFile audio)
        {
            ChatId = chatId;
            Audio = audio;
        }
    }
}
