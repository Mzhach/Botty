using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for getting incoming updates
    /// </summary>
    public class GetUpdatesRequest
    {
        /// <summary>
        /// Identifier of the first update to be returned
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Limits the number of updates to be retrieved
        /// Values between 1-100 are accepted
        /// </summary>
        public byte? Limit { get; set; }

        /// <summary>
        /// Timeout in seconds for long polling
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// A list of the update types you want your bot to receive
        /// </summary>
        public UpdateType[]? AllowedUpdates { get; set; }
    }
}
