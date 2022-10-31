using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Converters.Json
{
    /// <summary>
    /// DateTime converter for Unix format
    /// </summary>
    internal class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        /// <inheritdoc />
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var seconds = reader.GetInt64();
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(seconds);
            return dateTimeOffset.UtcDateTime;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteNumberValue(((DateTimeOffset)value).ToUnixTimeSeconds());
    }
}
