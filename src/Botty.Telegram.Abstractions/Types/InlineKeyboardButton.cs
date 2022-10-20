using System;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents one button of an inline keyboard
    /// </summary>
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Optional. HTTP or tg:// URL to be opened when the button is pressed
        /// </summary>
        public string? Url { get; }

        /// <summary>
        /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
        /// </summary>
        public string? CallbackData { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Label text</param>
        /// <param name="url">URL</param>
        /// <param name="callbackData">Callback data</param>
        public InlineKeyboardButton(
            string text,
            string? url = default,
            string? callbackData = default)
        {
            if (url is null && callbackData is null)
                throw new ArgumentException("Cannot create inline keyboard button only with text");

            Text = text;
            Url = url;
            CallbackData = callbackData;
        }
    }
}
