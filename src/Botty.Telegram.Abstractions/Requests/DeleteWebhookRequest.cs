namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for deleting webhook integration
    /// </summary>
    public class DeleteWebhookRequest
    {
        /// <summary>
        /// Pass True to drop all pending updates
        /// </summary>
        public bool? DropPendingUpdates { get; set; }
    }
}
