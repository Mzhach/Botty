using System.Text.Json;
using System.Text.Json.Serialization;

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
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = 
            {
                new SnakeCaseEnumFactoryConverter(),
                new JsonStringEnumConverter(),
                new UnixDateTimeConverter(),
                new ReplyMarkupConverter()
            }
        };
    }
}