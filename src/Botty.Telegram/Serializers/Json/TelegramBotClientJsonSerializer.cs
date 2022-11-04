using Botty.Telegram.Converters.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Serializers.Json
{
    /// <summary>
    /// Serializer for Telegram Bot API
    /// </summary>
    public static class TelegramBotClientJsonSerializer
    {
        /// <summary>
        /// Json serializer options
        /// </summary>
        public static JsonSerializerOptions Options { get; }

        static TelegramBotClientJsonSerializer()
        {
            Options = new JsonSerializerOptions
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

        /// <summary>
        /// Converts the value of a type specified by a generic type parameter into a JSON string
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize</typeparam>
        /// <param name="value">The value to convert</param>
        /// <returns>A JSON string representation of the value</returns>
        public static string Serialize<TValue>(TValue value) => JsonSerializer.Serialize(value, Options);

        /// <summary>
        /// Converts the value of a type specified by a generic type parameter into a JSON string
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="inputType">The type of the value to conver</param>
        /// <returns>A JSON string representation of the value</returns>
        public static string Serialize<TValue>(TValue value, Type inputType) => JsonSerializer.Serialize(value, inputType, Options);

#pragma warning disable CS8603 // Possible null reference return.

        /// <summary>
        /// Reads the UTF-8 encoded text representing a single JSON value into a TValue. The Stream will be read to completion.
        /// </summary>
        /// <typeparam name="TValue">The type to deserialize the JSON value into</typeparam>
        /// <param name="utf8Json">JSON data to parse</param>
        /// <returns>A TValue representation of the JSON value</returns>
        public static TValue Deserialize<TValue>(Stream utf8Json) => JsonSerializer.Deserialize<TValue>(utf8Json, Options);

#pragma warning restore CS8603 // Possible null reference return.
    }
}
