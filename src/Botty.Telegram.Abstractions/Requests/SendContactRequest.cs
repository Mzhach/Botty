using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending contact
    /// </summary>
    public class SendContactRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Contact's phone number
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Contact's first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Contact's last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Additional data about the contact in the form of a vCard, 0-2048 bytes
        /// </summary>
        public string? Vcard { get; set; }

        /// <summary>
        /// Optional. Sends the message silently. Users will receive a notification with no sound
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional. Protects the contents of the sent message from forwarding
        /// </summary>
        public bool? ProtectContent { get; set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional. Pass True if the message should be sent even if the specified replied-to message is not found
        /// </summary>
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Optional. Additional interface options
        /// </summary>
        public IReplyMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="phoneNumber">Phone number</param>
        /// <param name="firstName">First name</param>
        public SendContactRequest(string chatId, string phoneNumber, string firstName)
        {
            ChatId = chatId;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
        }
    }
}
