using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;

namespace Botty.Telegram.Abstractions.Requests
{
    /// <summary>
    /// Request for setting webhook
    /// </summary>
    public class SetWebhookRequest
    {
        /// <summary>
        /// HTTPS URL to send updates to. Use an empty string to remove webhook integration
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Upload your public key certificate so that the root certificate in use can be checked
        /// </summary>
        public InputFile? Certificate { get; set; }

        /// <summary>
        /// The fixed IP address which will be used to send webhook requests instead of the IP address resolved through DNS
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// The maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery, 1-100. Defaults to 40
        /// </summary>
        public byte? MaxConnections { get; set; }

        /// <summary>
        /// A JSON-serialized list of the update types you want your bot to receive
        /// </summary>
        public UpdateType[]? AllowedUpdates { get; set; }

        /// <summary>
        /// Pass True to drop all pending updates
        /// </summary>
        public bool? DropPendingUpdates { get; set; }

        /// <summary>
        /// A secret token to be sent in a header “X-Telegram-Bot-Api-Secret-Token” in every webhook request, 1-256 characters
        /// </summary>
        public string? SecretToken { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">URL</param>
        public SetWebhookRequest(string url)
        {
            Url = url;
        }
    }
}
