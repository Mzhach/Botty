namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user
    /// (act as if the user has selected the bot's message and tapped 'Reply')
    /// </summary>
    public class ForceReply : IReplyMarkup
    {
        /// <summary>
        /// Optional. The placeholder to be shown in the input field when the reply is active; 1-64 characters
        /// </summary>
        public string? InputFieldPlaceholder { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only
        /// </summary>
        public bool? Selective { get; set; }
    }
}
