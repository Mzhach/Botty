namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Represents a video to be sent
    /// </summary>
    public class InputMediaVideo : InputMedia
    {
        /// <summary>
        /// Type of the result, must be video
        /// </summary>
        public override string Type => "video";

        /// <summary>
        /// Optional. Thumbnail of the file sent
        /// </summary>
        public InputFile? Thumb { get; }

        /// <summary>
        /// Optional. Video width
        /// </summary>
        public int? Width { get; }

        /// <summary>
        /// Optional. Video height
        /// </summary>
        public int? Height { get; }

        /// <summary>
        /// Optional. Video duration in seconds
        /// </summary>
        public int? Duration { get; }

        /// <summary>
        /// Optional. Pass True if the uploaded video is suitable for streaming
        /// </summary>
        public bool? SupportsStreaming { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMediaVideo(InputFile media) : base(media)
        {
        }
    }
}
