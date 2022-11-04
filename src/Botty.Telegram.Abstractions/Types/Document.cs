namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a general file (as opposed to photos, voice messages and audio files)
    /// </summary>
    public class Document
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
        /// Optional. Document thumbnail as defined by sender
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
        /// <param name="thumb">Document thumb</param>
        /// <param name="fileName">File name</param>
        /// <param name="mimeType">MIME type</param>
        /// <param name="fileSize">File size</param>
        public Document(
            string fileId,
            string fileUniqueId,
            PhotoSize? thumb = default,
            string? fileName = default,
            string? mimeType = default,
            long? fileSize = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Thumb = thumb;
            FileName = fileName;
            MimeType = mimeType;
            FileSize = fileSize;
        }
    }
}
