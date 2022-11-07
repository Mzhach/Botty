namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an animation file (GIF or H.264/MPEG-4 AVC video without sound)
    /// </summary>
    public class Animation
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
        /// Optional. Animation thumbnail as defined by sender
        /// </summary>
        public PhotoSize? Thumb { get; }

        /// <summary>
        /// Optional. Original animation filename as defined by sender
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
        /// <param name="width">Animation width</param>
        /// <param name="height">Animation heigth</param>
        /// <param name="duration">Animation duration</param>
        /// <param name="thumb">Animation thumb</param>
        /// <param name="fileName">File name</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="fileSize">File size</param>
        public Animation(
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
