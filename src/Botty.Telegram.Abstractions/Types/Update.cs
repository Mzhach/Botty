namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    public class Update
    {
        /// <summary>
        /// The update's unique identifier
        /// </summary>
        public long UpdateId { get; }

        /// <summary>
        /// Optional. New incoming message of any kind - text, photo, sticker, etc
        /// </summary>
        public Message? Message { get; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        public Message? EditedMessage { get; }

        /// <summary>
        /// Optional. New incoming callback query
        /// </summary>
        public CallbackQuery? CallbackQuery { get; }

        /// <summary>
        /// Optional. New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot
        /// </summary>
        public Poll? Poll { get; }

        /// <summary>
        /// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself
        /// </summary>
        public PollAnswer? PollAnswer { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="updateId">Update`s unique identifier</param>
        /// <param name="message">Incoming message</param>
        /// <param name="editedMessage">New version of a message</param>
        /// <param name="callbackQuery">New incoming callback query</param>
        /// <param name="poll">Poll</param>
        /// <param name="pollAnswer">Poll answer</param>
        public Update(
            long updateId,
            Message? message = default,
            Message? editedMessage = default,
            CallbackQuery? callbackQuery = default,
            Poll? poll = default,
            PollAnswer? pollAnswer = default)
        {
            UpdateId = updateId;
            Message = message;
            EditedMessage = editedMessage;
            CallbackQuery = callbackQuery;
            Poll = poll;
            PollAnswer = pollAnswer;
        }
    }
}
