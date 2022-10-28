using Botty.Telegram.Extensions;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Converters.Json
{
    /// <summary>
    /// Snake case converter for enums 
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    internal class SnakeCaseEnumConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct
    {
        private const char Undescore = '_';

        /// <inheritdoc />
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            var enumValue = new StringBuilder();
            enumValue.Append(char.ToUpper(stringValue![0]));

            for (var i = 1; i < stringValue.Length; i++)
            {
                if (stringValue[i] == Undescore)
                    enumValue.Append(char.ToUpper(stringValue[++i]));
                else
                    enumValue.Append(stringValue[i]);
            }

            return Enum.Parse<TEnum>(enumValue.ToString());
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString().ToSnakeCase());
    }
}
