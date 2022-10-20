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
        /// Optional. New incoming callback query
        /// </summary>
        public CallbackQuery? CallbackQuery { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="updateId">Update`s unique identifier</param>
        /// <param name="message">Incoming message</param>
        public Update(long updateId, Message? message = default, CallbackQuery callbackQuery = default)
        {
            UpdateId = updateId;
            Message = message;
            CallbackQuery = callbackQuery;
        }
    }
}
