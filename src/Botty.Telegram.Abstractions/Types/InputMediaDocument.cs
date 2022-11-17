namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Represents a general file to be sent
    /// </summary>
    public class InputMediaDocument : InputMedia
    {
        /// <summary>
        /// Type of the result, must be document
        /// </summary>
        public override string Type => "document";

        /// <summary>
        /// Optional. Thumbnail of the file sent
        /// </summary>
        public InputFile? Thumb { get; }

        /// <summary>
        /// Optional. Disables automatic server-side content type detection
        /// </summary>
        public bool? DisableContentTypeDetection { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMediaDocument(InputFile media) : base(media)
        {
        }
    }
}
