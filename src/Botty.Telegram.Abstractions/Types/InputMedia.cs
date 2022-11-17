using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents the content of a media message to be sent
    /// </summary>
    public abstract class InputMedia
    {
        /// <summary>
        /// Type of the result
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// File to send
        /// </summary>
        public InputFile Media { get; }

        /// <summary>
        /// Optional. Caption of the file to be sent, 0-1024 characters after entities parsing
        /// </summary>
        public string? Caption { get; set; }

        /// <summary>
        /// Optional. Mode for parsing entities in the file caption
        /// </summary>
        public ParseMode? ParseMode { get; set; }

        /// <summary>
        /// Optional. List of special entities that appear in the caption
        /// </summary>
        public MessageEntity[]? CaptionEntities { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMedia(InputFile media)
        {
            Media = media;
        }
    }
}
