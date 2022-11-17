namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Represents a photo to be sent
    /// </summary>
    public class InputMediaPhoto : InputMedia
    {
        /// <summary>
        /// Type of the result, must be photo
        /// </summary>
        public override string Type => "photo";

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMediaPhoto(InputFile media) : base(media)
        {
        }
    }
}
