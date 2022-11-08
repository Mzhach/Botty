namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a voice note
    /// </summary>
    public class Voice
    {
        /// <summary>
        /// dentifier for this file, which can be used to download or reuse the file
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots
        /// </summary>
        public string FileUniqueId { get; }

        /// <summary>
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string? MimeType { get; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public long? FileSize { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="duration">Duration</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="fileSize">File size</param>
        public Voice(
            string fileId,
            string fileUniqueId,
            int duration,
            string? mimeType,
            long? fileSize)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Duration = duration;
            MimeType = mimeType;
            FileSize = fileSize;
        }
    }
}
