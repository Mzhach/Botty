using Botty.Telegram.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Botty.Telegram.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Extensions for service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Telegram client
        /// </summary>
        /// <param name="serviceCollection">Service collections</param>
        /// <param name="token">API token</param>
        /// <param name="baseUrl">Base Telegram API URL</param>
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection serviceCollection, string token, string? baseUrl = default)
        {
            var options = new TelegramBotClientOptions(token, baseUrl);

            serviceCollection.AddSingleton(options);
            serviceCollection.AddHttpClient<ITelegramBotClient, TelegramBotClient>();
            serviceCollection.AddScoped<ITelegramBotClient, TelegramBotClient>();

            return serviceCollection;
        }
    }
}
