namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object represents a venue
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Venue location. Can't be a live location
        /// </summary>
        public Location Location { get; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Optional. Foursquare identifier of the venue
        /// </summary>
        public string? FoursquareId { get; }

        /// <summary>
        /// Optional. Foursquare type of the venue
        /// </summary>
        public string? FoursquareType { get; }

        /// <summary>
        /// Optional. Google Places identifier of the venue
        /// </summary>
        public string? GooglePlaceId { get; }

        /// <summary>
        /// Optional. Google Places type of the venue
        /// </summary>
        public string? GooglePlaceType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="title">Title</param>
        /// <param name="address">Address</param>
        /// <param name="foursquareId">Foursquare identifier</param>
        /// <param name="foursquareType">Foursquare type</param>
        /// <param name="googlePlaceId">Google place identifier</param>
        /// <param name="googlePlaceType">Google place type</param>
        public Venue(
            Location location,
            string title,
            string address,
            string? foursquareId = default,
            string? foursquareType = default,
            string? googlePlaceId = default,
            string? googlePlaceType = default)
        {
            Location = location;
            Title = title;
            Address = address;
            FoursquareId = foursquareId;
            FoursquareType = foursquareType;
            GooglePlaceId = googlePlaceId;
            GooglePlaceType = googlePlaceType;
        }
    }
}
