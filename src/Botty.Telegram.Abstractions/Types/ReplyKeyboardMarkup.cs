namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a custom keyboard with reply options
    /// </summary>
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows
        /// </summary>
        public KeyboardButton[][] Keyboard { get; }

        /// <summary>
        /// Optional. Requests clients to resize the keyboard vertically for optimal fit
        /// </summary>
        public bool? ResizeKeyboard { get; set; }

        /// <summary>
        /// Optional. Requests clients to hide the keyboard as soon as it's been used
        /// </summary>
        public bool? OneTimeKeyboard { get; set; }

        /// <summary>
        /// Optional. The placeholder to be shown in the input field when the keyboard is active; 1-64 characters
        /// </summary>
        public string? InputFieldPlaceholder { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to show the keyboard to specific users only
        /// </summary>
        public bool? Selective { get; set; }

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="keyboard">Keyboard</param>
        public ReplyKeyboardMarkup(KeyboardButton[][] keyboard)
        {
            Keyboard = keyboard;
        }
    }
}
