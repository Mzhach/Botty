using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for sending location
    /// </summary>
    public class SendLocationRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Latitude of the location
        /// </summary>
        public float Latitude { get; }

        /// <summary>
        /// Longitude of the location
        /// </summary>
        public float Longitude { get; }

        /// <summary>
        /// The radius of uncertainty for the location, measured in meters; 0-1500
        /// </summary>
        public float? HorizontalAccuracy { get; set; }

        /// <summary>
        /// Period in seconds for which the location will be updated, should be between 60 and 86400
        /// </summary>
        public int? LivePeriod { get; set; }

        /// <summary>
        /// For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified
        /// </summary>
        public int? Heading { get; set; }

        /// <summary>
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified
        /// </summary>
        public int? ProximityAlertRadius { get; set; }

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
        public SendLocationRequest(string chatId, float latitude, float longitude)
        {
            ChatId = chatId;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
