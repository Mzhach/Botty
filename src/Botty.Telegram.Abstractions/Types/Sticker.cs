using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a sticker
    /// </summary>
    public class Sticker
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
        /// Type of the sticker
        /// </summary>
        public StickerType Type { get; }

        /// <summary>
        /// Sticker width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Sticker height
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// True, if the sticker is animated
        /// </summary>
        public bool IsAnimated { get; }

        /// <summary>
        /// True, if the sticker is a video sticker
        /// </summary>
        public bool IsVideo { get; }

        /// <summary>
        /// Optional. Sticker thumbnail in the .WEBP or .JPG format
        /// </summary>
        public PhotoSize? Thumb { get; }

        /// <summary>
        /// Optional. Emoji associated with the sticker
        /// </summary>
        public string? Emoji { get; }

        /// <summary>
        /// Optional. Name of the sticker set to which the sticker belongs
        /// </summary>
        public string? SetName { get; }

        /// <summary>
        /// Optional. For premium regular stickers, premium animation for the sticker
        /// </summary>
        public File? PremiumAnimation { get; }

        /// <summary>
        /// Optional. For mask stickers, the position where the mask should be placed
        /// </summary>
        public MaskPosition? MaskPosition { get; }

        /// <summary>
        /// Optional. For custom emoji stickers, unique identifier of the custom emoji
        /// </summary>
        public string? CustomEmojiId { get; }

        /// <summary>
        /// Optional. File size in bytes
        /// </summary>
        public long? FileSize { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileId">File identifier</param>
        /// <param name="fileUniqueId">Unique file identifier</param>
        /// <param name="type">Sticker type</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="isAnimated">Is animated</param>
        /// <param name="isVideo">Is video</param>
        /// <param name="thumb">Thumb</param>
        /// <param name="emoji">Emoji</param>
        /// <param name="setName">Set name</param>
        /// <param name="premiumAnimation">Premium animation</param>
        /// <param name="maskPosition">Mask position</param>
        /// <param name="customEmojiId">Custom emoji identifier</param>
        /// <param name="fileSize">File size</param>
        public Sticker(
            string fileId,
            string fileUniqueId,
            StickerType type,
            int width,
            int height,
            bool isAnimated,
            bool isVideo,
            PhotoSize? thumb = default,
            string? emoji = default,
            string? setName = default,
            File? premiumAnimation = default,
            MaskPosition? maskPosition = default,
            string? customEmojiId = default,
            long? fileSize = default)
        {
            FileId = fileId;
            FileUniqueId = fileUniqueId;
            Type = type;
            Width = width;
            Height = height;
            IsAnimated = isAnimated;
            IsVideo = isVideo;
            Thumb = thumb;
            Emoji = emoji;
            SetName = setName;
            PremiumAnimation = premiumAnimation;
            MaskPosition = maskPosition;
            CustomEmojiId = customEmojiId;
            FileSize = fileSize;
        }
    }
}
