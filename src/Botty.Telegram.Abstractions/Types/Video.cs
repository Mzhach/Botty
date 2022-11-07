namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a video file
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots
        /// </summary>
        public string FileUniqueId { get; }

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        public PhotoSize? Thumb { get; }

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
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="width">Video width</param>
        /// <param name="height">Video heigth</param>
        /// <param name="duration">Video duration</param>
        /// <param name="thumb">Video thumb</param>
        /// <param name="fileName">File name</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="fileSize">File size</param>
        public Video(
            string fileId,
            string fileUniqueId,
            int width,
            int height,
            int duration,
            PhotoSize? thumb = default,
            string? fileName = default,
            string? mimeType = default,
            long? fileSize = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Width = width;
            Height = height;
            Duration = duration;
            Thumb = thumb;
            FileName = fileName;
            MimeType = mimeType;
            FileSize = fileSize;
        }
    }
}
