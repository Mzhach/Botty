namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an inline keyboard
    /// </summary>
    public class CallbackQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Sender
        /// </summary>
        public User From { get; }

        /// <summary>
        /// Optional. Message with the callback button that originated the query
        /// </summary>
        public Message? Message { get; }

        /// <summary>
        /// Optional. Identifier of the message sent via the bot in inline mode, that originated the query.
        /// </summary>
        public string? InlineMessageId { get; }

        /// <summary>
        /// Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent
        /// </summary>
        public string ChatInstance { get; }

        /// <summary>
        /// Optional. Data associated with the callback button
        /// </summary>
        public string? Data { get; }

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="id">Unique identifier for this query</param>
        /// <param name="from">Sender</param>
        /// <param name="chatInstance">Global identifier</param>
        /// <param name="message">Message</param>
        /// <param name="inlineMessageId">Inline message identifier</param>
        /// <param name="data">Data</param>
        public CallbackQuery(
            string id,
            User from,
            string chatInstance,
            Message? message = default,
            string? inlineMessageId = default,
            string? data = default)
        {
            Id = id;
            From = from;
            ChatInstance = chatInstance;
            Message = message;
            InlineMessageId = inlineMessageId;
            Data = data;
        }
    }
}
