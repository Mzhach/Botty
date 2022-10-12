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
        /// <param name="cancellationToken"></param>
        /// <returns>Bot basic information</returns>
        public Task<User> GetMeAsync(CancellationToken cancellationToken = default);
    }
}