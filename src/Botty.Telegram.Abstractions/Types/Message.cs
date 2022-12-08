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
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
        public User? ForwardFrom { get; }

        /// <summary>
        /// Optional. For messages forwarded from channels, identifier of the original message in the channel
        /// </summary>
        public long? ForwardFromMessageId { get; }

        /// <summary>
        /// Optional. For forwarded messages that were originally sent in channels or by an anonymous chat administrator, signature of the message sender if present
        /// </summary>
        public string? ForwardSignature { get; }

        /// <summary>
        /// Optional. Sender's name for messages forwarded from users who disallow adding a link to their account in forwarded messages
        /// </summary>
        public string? ForwardSenderName { get; }

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent
        /// </summary>
        public DateTime? ForwardDate { get; }

        /// <summary>
        /// Optional. True, if the message is a channel post that was automatically forwarded to the connected discussion group
        /// </summary>
        public bool? IsAutomaticForward { get; }

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
        /// Optional. Message is an animation, information about the animation. For backward compatibility, when this field is set, the document field will also be set
        /// </summary>
        public Animation? Animation { get; }

        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
        public Audio? Audio { get; }

        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        public Document? Document { get; }

        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        public PhotoSize[]? Photo { get; }

        /// <summary>
        /// Optional. Message is a sticker, information about the sticker
        /// </summary>
        public Sticker? Sticker { get; }

        /// <summary>
        /// Optional. Message is a video, information about the video
        /// </summary>
        public Video? Video { get; }

        /// <summary>
        /// Optional. Message is a video note, information about the video message
        /// </summary>
        public VideoNote? VideoNote { get; }

        /// <summary>
        /// Optional. Message is a voice message, information about the file
        /// </summary>
        public Voice? Voice { get; }

        /// <summary>
        /// Optional. Caption for the animation, audio, document, photo, video or voice
        /// </summary>
        public string? Caption { get; }

        /// <summary>
        /// Optional. For messages with a caption, special entities like usernames, URLs, bot commands, etc. that appear in the caption
        /// </summary>
        public MessageEntity[]? CaptionEntities { get; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        public Contact? Contact { get; }

        /// <summary>
        /// Optional. Message is a dice with random value
        /// </summary>
        public Dice? Dice { get; }

        /// <summary>
        /// Optional. Message is a native poll, information about the poll
        /// </summary>
        public Poll? Poll { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageId">Message identifier</param>
        /// <param name="date">Message date</param>
        /// <param name="chat">Chat</param>
        /// <param name="forwardFrom">Forward from</param>
        /// <param name="forwardFromMessageId">Forward from message identifier</param>
        /// <param name="forwardSignature">Forward signature</param>
        /// <param name="forwardSenderName">Forward sender name</param>
        /// <param name="forwardDate">Forward date</param>
        /// <param name="isAutomaticForward">Is automatic forward</param>
        /// <param name="text">Text</param>
        /// <param name="user">User</param>
        /// <param name="senderChat">Sender chat</param>
        /// <param name="replyToMessage">Reply to message</param>
        /// <param name="viaBot">Via bot</param>
        /// <param name="editDate">Edit date</param>
        /// <param name="entities">Entities</param>
        /// <param name="animation">Animation</param>
        /// <param name="audio">Audio</param>
        /// <param name="document">Document</param>
        /// <param name="photo">Photo sizes</param>
        /// <param name="sticker">Sticker</param>
        /// <param name="video">Video</param>
        /// <param name="videoNote">Video note</param>
        /// <param name="voice">Voice</param>
        /// <param name="caption">Caption</param>
        /// <param name="captionEntities">Caption entities</param>
        /// <param name="contact">Contact</param>
        /// <param name="dice">Dice</param>
        /// <param name="poll">Poll</param>
        public Message(
            long messageId,
            DateTime date,
            Chat chat,
            User? forwardFrom = default,
            long? forwardFromMessageId = default,
            string? forwardSignature = default,
            string? forwardSenderName = default,
            DateTime? forwardDate = default,
            bool? isAutomaticForward = default,
            string? text = default,
            User? user = default,
            Chat? senderChat = default,
            Message? replyToMessage = default,
            User? viaBot = default,
            DateTime? editDate = default,
            MessageEntity[]? entities = default,
            Animation? animation = default,
            Audio? audio = default,
            Document? document = default,
            PhotoSize[]? photo = default,
            Sticker? sticker = default,
            Video? video = default,
            VideoNote? videoNote = default,
            Voice? voice = default,
            string? caption = default,
            MessageEntity[]? captionEntities = default,
            Contact? contact = default,
            Dice? dice = default,
            Poll? poll = default)
        {
            MessageId = messageId;
            Date = date;
            Chat = chat;
            ForwardFrom = forwardFrom;
            ForwardFromMessageId = forwardFromMessageId;
            ForwardSignature = forwardSignature;
            ForwardSenderName = forwardSenderName;
            ForwardDate = forwardDate;
            IsAutomaticForward = isAutomaticForward;
            Text = text;
            User = user;
            SenderChat = senderChat;
            ReplyToMessage = replyToMessage;
            ViaBot = viaBot;
            EditDate = editDate;
            Entities = entities;
            Animation = animation;
            Audio = audio;
            Document = document;
            Photo = photo;
            Sticker = sticker;
            Video = video;
            VideoNote = videoNote;
            Voice = voice;
            Caption = caption;
            CaptionEntities = captionEntities;
            Contact = contact;
            Dice = dice;
            Poll = poll;
        }
    }
}
