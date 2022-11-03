namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents one size of a photo or a file / sticker thumbnail
    /// </summary>
    public class PhotoSize
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
        /// Photo width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Photo height
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public int? FileSize { get; }

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="width">Photo width</param>
        /// <param name="height">Photo height</param>
        /// <param name="fileSize">File size</param>
        public PhotoSize(
            string fileId,
            string fileUniqueId,
            int width,
            int height,
            int? fileSize = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Width = width;
            Height = height;
            FileSize = fileSize;
        }
    }
}
