using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending venue
    /// </summary>
    public class SendVenueRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Latitude of the venue
        /// </summary>
        public float Latitude { get; }

        /// <summary>
        /// Longitude of the venue
        /// </summary>
        public float Longitude { get; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Foursquare identifier of the venue
        /// </summary>
        public string? FoursquareId { get; set; }

        /// <summary>
        /// Foursquare type of the venue
        /// </summary>
        public string? FoursquareType { get; set; }

        /// <summary>
        /// Google Places identifier of the venue
        /// </summary>
        public string? GooglePlaceId { get; set; }

        /// <summary>
        /// Google Places type of the venue
        /// </summary>
        public string? GooglePlaceType { get; set; }

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
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="title">Title</param>
        /// <param name="address">Address</param>
        public SendVenueRequest(
            string chatId,
            float latitude,
            float longitude,
            string title,
            string address)
        {
            ChatId = chatId;
            Latitude = latitude;
            Longitude = longitude;
            Title = title;
            Address = address;
        }
    }
}
