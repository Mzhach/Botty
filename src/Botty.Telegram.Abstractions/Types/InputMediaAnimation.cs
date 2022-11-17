namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent
    /// </summary>
    public class InputMediaAnimation : InputMedia
    {
        /// <summary>
        /// Type of the result, must be animation
        /// </summary>
        public override string Type => "animation";

        /// <summary>
        /// Optional. Thumbnail of the file sent
        /// </summary>
        public InputFile? Thumb { get; }

        /// <summary>
        /// Optional. Animation width
        /// </summary>
        public int? Width { get; }

        /// <summary>
        /// Optional. Animation height
        /// </summary>
        public int? Height { get; }

        /// <summary>
        /// Optional. Animation duration in seconds
        /// </summary>
        public int? Duration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMediaAnimation(InputFile media) : base(media)
        {
        }
    }
}
