namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a Telegram user or bot
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// True, if this user is a bot
        /// </summary>
        public bool IsBot { get; }

        /// <summary>
        /// User's or bot's first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Optional. User's or bot's last name
        /// </summary>
        public string? LastName { get; }

        /// <summary>
        /// Optional. User's or bot's username
        /// </summary>
        public string? Username { get; }

        /// <summary>
        /// Optional. IETF language tag of the user's language
        /// </summary>
        public string? LanguageCode { get; }

        /// <summary>
        /// Optional. True, if this user is a Telegram Premium user
        /// </summary>
        public bool? IsPremium { get; }

        /// <summary>
        /// Optional. True, if this user added the bot to the attachment menu
        /// </summary>
        public bool? AddedToAttachmentMenu { get; }

        /// <summary>
        /// True, if the bot can be invited to groups
        /// </summary>
        public bool? CanJoinGroups { get; }

        /// <summary>
        /// True, if privacy mode is disabled for the bot
        /// </summary>
        public bool? CanReadAllGroupMessages { get; }

        /// <summary>
        /// True, if the bot supports inline queries
        /// </summary>
        public bool? SupportsInlineQueries { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="isBot">Is bot</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="userName">User name</param>
        /// <param name="languageCode">Language code</param>
        /// <param name="isPremium">Is premium</param>
        /// <param name="addedToAttachmentMenu">Added to attachment menu</param>
        /// <param name="canJoinGroups">Can join groups</param>
        /// <param name="canReadAllGroupMessages">Can read all group messages</param>
        /// <param name="supportsInlineQueries">Supports inline messages</param>
        public User(
            long id,
            bool isBot,
            string firstName,
            string? lastName = default,
            string? username = default,
            string? languageCode = default,
            bool? isPremium = default,
            bool? addedToAttachmentMenu = default,
            bool? canJoinGroups = default,
            bool? canReadAllGroupMessages = default,
            bool? supportsInlineQueries = default)
        {
            Id = id;
            IsBot = isBot;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            LanguageCode = languageCode;
            IsPremium = isPremium;
            AddedToAttachmentMenu = addedToAttachmentMenu;
            CanJoinGroups = canJoinGroups;
            CanReadAllGroupMessages = canReadAllGroupMessages;
            SupportsInlineQueries = supportsInlineQueries;
        }
    }
}