using Botty.Telegram.Abstractions.Enums;
using System;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// Describes the current status of a webhook
    /// </summary>
    public class WebhookInfo
    {
        /// <summary>
        /// Webhook URL, may be empty if webhook is not set up
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// True, if a custom certificate was provided for webhook certificate checks
        /// </summary>
        public bool HasCustomCertificate { get; }

        /// <summary>
        /// Number of updates awaiting delivery
        /// </summary>
        public int PendingUpdateCount { get; }

        /// <summary>
        /// Optional. Currently used webhook IP address
        /// </summary>
        public string? IpAddress { get; }

        /// <summary>
        /// Optional. Time for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        public DateTime? LastErrorDate { get; }

        /// <summary>
        /// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook
        /// </summary>
        public string? LastErrorMessage { get; }

        /// <summary>
        /// Optional. Time of the most recent error that happened when trying to synchronize available updates with Telegram datacenters
        /// </summary>
        public DateTime? LastSynchronizationErrorDate { get; }

        /// <summary>
        /// Optional. The maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
        /// </summary>
        public byte? MaxConnections { get; }

        /// <summary>
        /// Optional. A list of update types the bot is subscribed to
        /// </summary>
        public UpdateType[]? AllowedUpdates { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="hasCustomCertificate">Has custom certificate</param>
        /// <param name="pendingUpdateCount">Pending update count</param>
        /// <param name="ipAddress">IP address</param>
        /// <param name="lastErrorDate">Last error date</param>
        /// <param name="lastErrorMessage">Last error message</param>
        /// <param name="lastSynchronizationErrorDate">Last synchronization error date</param>
        /// <param name="maxConnections">Max connections</param>
        /// <param name="allowedUpdates">Allowed update</param>
        public WebhookInfo(
            string url,
            bool hasCustomCertificate,
            int pendingUpdateCount,
            string? ipAddress = default,
            DateTime? lastErrorDate = default,
            string? lastErrorMessage = default,
            DateTime? lastSynchronizationErrorDate = default,
            byte? maxConnections = default,
            UpdateType[]? allowedUpdates = default)
        {
            Url = url;
            HasCustomCertificate = hasCustomCertificate;
            PendingUpdateCount = pendingUpdateCount;
            IpAddress = ipAddress;
            LastErrorMessage = lastErrorMessage;
            LastSynchronizationErrorDate = lastSynchronizationErrorDate;
            MaxConnections = maxConnections;
            AllowedUpdates = allowedUpdates;
        }
    }
}
