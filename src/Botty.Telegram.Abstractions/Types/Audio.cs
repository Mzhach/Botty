namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an audio file to be treated as music by the Telegram clients
    /// </summary>
    public class Audio
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
        /// Optional. Performer of the audio as defined by sender or by audio tags
        /// </summary>
        public string? Performer { get; }

        /// <summary>
        /// Optional. Title of the audio as defined by sender or by audio tags
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Optional. Original filename as defined by sender
        /// </summary>
        public string? FileName { get; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string? MimeType { get; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public long? FileSize { get; }

        /// <summary>
        /// Optional. Thumbnail of the album cover to which the music file belongs
        /// </summary>
        public PhotoSize? Thumb { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="duration">Duration</param>
        /// <param name="performer">Performer</param>
        /// <param name="title">Title</param>
        /// <param name="fileName">File name</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="fileSize">File size</param>
        /// <param name="thumb">Thumb</param>
        public Audio(
            string fileId,
            string fileUniqueId,
            int duration,
            string? performer = default,
            string? title = default,
            string? fileName = default,
            string? mimeType = default,
            long? fileSize = default,
            PhotoSize? thumb = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Duration = duration;
            Performer = performer;
            Title = title;
            FileName = fileName;
            MimeType = mimeType;
            FileSize = fileSize;
            Thumb = thumb;
        }
    }
}
