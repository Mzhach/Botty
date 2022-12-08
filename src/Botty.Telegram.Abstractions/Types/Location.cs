namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a point on the map
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Longitude as defined by sender
        /// </summary>
        public float Longitude { get; }

        /// <summary>
        /// Latitude as defined by sender
        /// </summary>
        public float Latitude { get; }

        /// <summary>
        /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
        /// </summary>
        public float? HorizontalAccuracy { get; }

        /// <summary>
        /// Optional. Time relative to the message sending date, during which the location can be updated; in seconds. For active live locations only
        /// </summary>
        public int? LivePeriod { get; }

        /// <summary>
        /// Optional. The direction in which user is moving, in degrees; 1-360. For active live locations only
        /// </summary>
        public int? Heading { get; }

        /// <summary>
        /// Optional. The maximum distance for proximity alerts about approaching another chat member, in meters. For sent live locations only
        /// </summary>
        public int? ProximityAlertRadius { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latituder</param>
        /// <param name="horizontalAccuracy">Horizontal accuracy</param>
        /// <param name="livePeriod">live period</param>
        /// <param name="heading">Heading</param>
        /// <param name="proximityAlertRadius">Proximity alert radius</param>
        public Location(
            float longitude,
            float latitude,
            float? horizontalAccuracy = default,
            int? livePeriod = default,
            int? heading = default,
            int? proximityAlertRadius = default)
        {
            Longitude = longitude;
            Latitude = latitude;
            HorizontalAccuracy = horizontalAccuracy;
            LivePeriod = livePeriod;
            Heading = heading;
            ProximityAlertRadius = proximityAlertRadius;
        } 
    }
}
