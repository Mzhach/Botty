namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will remove the current custom keyboard and display the default letter-keyboard
    /// </summary>
    public class ReplyKeyboardRemove : IReplyMarkup
    {
        /// <summary>
        /// Optional. Use this parameter if you want to remove the keyboard for specific users only
        /// </summary>
        public bool? Selective { get; set; }
    }
}
