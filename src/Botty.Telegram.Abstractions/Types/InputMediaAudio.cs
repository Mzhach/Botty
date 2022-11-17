namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Represents an audio file to be treated as music to be sent
    /// </summary>
    public class InputMediaAudio : InputMedia
    {
        /// <summary>
        /// Type of the result, must be audio
        /// </summary>
        public override string Type => "audio";

        /// <summary>
        /// Optional. Thumbnail of the file sent
        /// </summary>
        public InputFile? Thumb { get; }

        /// <summary>
        /// Optional. Duration of the audio in seconds
        /// </summary>
        public int? Duration { get; }

        /// <summary>
        /// Optional. Performer of the audio
        /// </summary>
        public string? Performer { get; }

        /// <summary>
        /// Optional. Title of the audio
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="media">File to send</param>
        public InputMediaAudio(InputFile media) : base(media)
        {
        }
    }
}
