namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a video message
    /// </summary>
    public class VideoNote
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
        /// Video width and height (diameter of the video message) as defined by sender
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        public PhotoSize? Thumb { get; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public long? FileSize { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="length">Video width and height</param>
        /// <param name="duration">Video duration</param>
        /// <param name="thumb">Video thumbnail</param>
        /// <param name="fileSize">File size</param>
        public VideoNote(
            string fileId,
            string fileUniqueId,
            int length,
            int duration,
            PhotoSize? thumb = default,
            long? fileSize = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Length = length;
            Duration = duration;
            Thumb = thumb;
            FileSize = fileSize;
        }
    }
}
