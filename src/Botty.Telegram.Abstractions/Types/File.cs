namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a file ready to be downloaded
    /// </summary>
    public class File
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
        /// Optional. File size in bytes
        /// </summary>
        public long? FileSize { get; }

        /// <summary>
        /// Optional. File path
        /// </summary>
        public string? FilePath { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="fileSize">File size</param>
        /// <param name="filePath">File path</param>
        public File(
            string fileId,
            string fileUniqueId,
            long? fileSize = default,
            string? filePath = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            FileSize = fileSize;
            FilePath = filePath;
        }
    }
}
