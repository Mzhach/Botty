using Botty.Telegram.Abstractions.Requests;
using Botty.Telegram.Abstractions.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Botty.Telegram.Abstractions
{
    /// <summary>
    /// Client for Telegram Bot API
    /// </summary>
    public interface ITelegramBotClient
    {
        /// <summary>
        /// Returns basic information about the bot
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Bot basic information</returns>
        public Task<User> GetMeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Receive incoming updates
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Update</returns>
        public Task<Update[]> GetUpdatesAsync(GetUpdatesRequest request, CancellationToken cancellationToken = default);
    }
}