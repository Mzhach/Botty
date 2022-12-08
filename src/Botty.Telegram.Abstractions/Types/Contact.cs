namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a phone contact
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Contact's phone number
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Contact's first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Optional. Contact's last name
        /// </summary>
        public string? LastName { get; }

        /// <summary>
        /// Optional. Contact's user identifier in Telegram
        /// </summary>
        public long? UserId { get; }

        /// <summary>
        /// Optional. Additional data about the contact in the form of a vCard
        /// </summary>
        public string? Vcard { get; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="userId">User identifier</param>
        /// <param name="vcard">vCard</param>
        public Contact(
            string phoneNumber,
            string firstName,
            string? lastName = default,
            long? userId = default,
            string? vcard = default)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            Vcard = vcard;
        }
    }
}
