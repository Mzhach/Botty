namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for forwarding message
    /// </summary>
    public class ForwardMessageRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername)
        /// </summary>
        public string FromChatId { get; }

        /// <summary>
        /// Message identifier in the chat specified in from_chat_id
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Protects the contents of the forwarded message from forwarding and saving
        /// </summary>
        public bool? ProtectContent { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="fromChatId">From chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        public ForwardMessageRequest(string chatId, string fromChatId, long messageId)
        {
            ChatId = chatId;
            FromChatId = fromChatId;
            MessageId = messageId;
        }
    }
}
