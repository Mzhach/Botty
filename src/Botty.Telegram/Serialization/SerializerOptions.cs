using System.Text.Json;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Predefined JSON seriliazer options
    /// </summary>
    internal static class SerializerOptions
    {
        /// <summary>
        /// JSON serializer options for Telegram Bot API
        /// </summary>
        public static readonly JsonSerializerOptions Telegram = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
            Converters = 
            { 
                new SnakeCaseEnumFactoryConverter(),
                new UnixDateTimeConverter()
            }
        };
    }
}