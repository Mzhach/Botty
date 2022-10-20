namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to
    /// </summary>
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows
        /// </summary>
        public InlineKeyboardButton[][] InlineKeyboard { get; }

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="inlineKeyboard">Keyboard</param>
        public InlineKeyboardMarkup(InlineKeyboardButton[][] inlineKeyboard)
        {
            InlineKeyboard = inlineKeyboard;
        }
    }
}
