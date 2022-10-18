using System;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Unique message identifier inside this chat
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// Optional. Sender of the message.
        /// Empty for messages sent to channels
        /// </summary>
        public User? User { get; }

        /// <summary>
        /// Optional. Sender of the message, sent on behalf of a chat
        /// </summary>
        public Chat? SenderChat { get; }

        /// <summary>
        /// Date the message was sent
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
        public Chat Chat { get; }

        /// <summary>
        /// Optional. For replies, the original message
        /// </summary>
        public Message? ReplyToMessage { get; }

        /// <summary>
        /// Optional. Bot through which the message was sent
        /// </summary>
        public User? ViaBot { get; }

        /// <summary>
        /// Optional. Date the message was last edited
        /// </summary>
        public DateTime? EditDate { get; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        public string? Text { get; }

        /// <summary>
        /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc
        /// </summary>
        public MessageEntity[]? Entities { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageId">Message identifier</param>
        /// <param name="date">Message date</param>
        /// <param name="chat">Chat</param>
        /// <param name="text">Text</param>
        /// <param name="user">User</param>
        /// <param name="senderChat">Sender chat</param>
        /// <param name="replyToMessage">Reply to message</param>
        /// <param name="viaBot">Via bot</param>
        /// <param name="editDate">Edit date</param>
        /// <param name="entities">Entities</param>
        public Message(
            long messageId,
            DateTime date,
            Chat chat,
            string? text,
            User? user = default,
            Chat? senderChat = default,
            Message? replyToMessage = default,
            User? viaBot = default,
            DateTime? editDate = default,
            MessageEntity[]? entities = default)
        {
            MessageId = messageId;
            Date = date;
            Chat = chat;
            Text = text;
            User = user;
            SenderChat = senderChat;
            ReplyToMessage = replyToMessage;
            ViaBot = viaBot;
            EditDate = editDate;
            Entities = entities;
        }
    }
}
