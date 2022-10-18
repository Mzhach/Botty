using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Unique identifier for this chat
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Type of chat
        /// </summary>
        public ChatType Type { get; }

        /// <summary>
        /// Optional. Title, for supergroups, channels and group chats
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        public string? FirstName { get; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        public string? LastName { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Chat identifier</param>
        /// <param name="type">Chat type</param>
        /// <param name="title">Title</param>
        /// <param name="username">User name</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        public Chat(long id,
            ChatType type,
            string? title = default,
            string? username = default,
            string? firstName = default,
            string? lastName = default)
        {
            Id = id;
            Type = type;
            Title = title;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
