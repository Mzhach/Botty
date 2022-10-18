using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Snake case converter factory for enums 
    /// </summary>
    internal class SnakeCaseEnumFactoryConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(SnakeCaseEnumConverter<>).MakeGenericType(typeToConvert);
            return Activator.CreateInstance(converterType) as JsonConverter;
        }
    }
}
