using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending chat action
    /// </summary>
    public class SendChatActionRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Type of action to broadcast
        /// </summary>
        public ActionType Action { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="action">Action to broadcast</param>
        public SendChatActionRequest(string chatId, ActionType action)
        {
            ChatId = chatId;
            Action = action;
        }
    }
}
