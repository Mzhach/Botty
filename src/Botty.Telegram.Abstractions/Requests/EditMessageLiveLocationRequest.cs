using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for editing live location
    /// </summary>
    public class EditMessageLiveLocationRequest
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Identifier of the message to edit
        /// </summary>
        public long MessageId { get; }

        /// <summary>
        /// Latitude of new location
        /// </summary>
        public float Latitude { get; }

        /// <summary>
        /// Longitude of new location
        /// </summary>
        public float Longitude { get; }

        /// <summary>
        /// The radius of uncertainty for the location, measured in meters; 0-1500
        /// </summary>
        public float? HorizontalAccuracy { get; set; }

        /// <summary>
        /// Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified
        /// </summary>
        public int? Heading { get; set; }

        /// <summary>
        /// The maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified
        /// </summary>
        public int? ProximityAlertRadius { get; set; }

        /// <summary>
        /// New inline keyboard
        /// </summary>
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="chatId">Chat identifier</param>
        /// <param name="messageId">Message identifier</param>
        /// <param name="latitude">Latitude of new location</param>
        /// <param name="longitude">Longitude of new location</param>
        public EditMessageLiveLocationRequest(
            string chatId,
            long messageId,
            float latitude,
            float longitude)
        {
            ChatId = chatId;
            MessageId = messageId;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
