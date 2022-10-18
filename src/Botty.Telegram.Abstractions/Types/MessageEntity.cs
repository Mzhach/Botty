using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents one special entity in a text message.
    /// For example, hashtags, usernames, URLs, etc
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Type of the entity
        /// </summary>
        public MessageEntityType Type { get; }

        /// <summary>
        /// Offset in UTF-16 code units to the start of the entity
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Length of the entity in UTF-16 code units
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Optional. For “text_link” only, URL that will be opened after user taps on the text
        /// </summary>
        public string? Url { get; }

        /// <summary>
        /// Optional. For “text_mention” only, the mentioned user
        /// </summary>
        public User? User { get; }

        /// <summary>
        /// Optional. For “pre” only, the programming language of the entity text
        /// </summary>
        public string? Language { get; }

        /// <summary>
        /// Optional. For “custom_emoji” only, unique identifier of the custom emoji
        /// </summary>
        public string? CustomEmojiId { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Message entity type</param>
        /// <param name="offset">Offset</param>
        /// <param name="length">Length</param>
        /// <param name="url">URL</param>
        /// <param name="user">Mentioned user</param>
        /// <param name="language">Program language</param>
        /// <param name="customEmojiId">Custom emoji id</param>
        public MessageEntity(
            MessageEntityType type,
            int offset,
            int length,
            string? url = default,
            User? user = default,
            string? language = default,
            string? customEmojiId = default)
        {
            Type = type;
            Offset = offset;
            Length = length;
            Url = url;
            User = user;
            Language = language;
            CustomEmojiId = customEmojiId;
        }
    }
}
