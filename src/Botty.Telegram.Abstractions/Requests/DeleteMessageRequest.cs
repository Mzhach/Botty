namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for deleting messages
    /// </summary>
    public class DeleteMessageRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Identifier of the message to delete
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        public DeleteMessageRequest(string chatId, long messageId)
        {
            ChatId = chatId;
            MessageId = messageId;
        }
    }
}
