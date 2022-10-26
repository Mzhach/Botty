using Botty.Telegram.Abstractions.Enums;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Snake case converter factory for enums 
    /// </summary>
    internal class SnakeCaseEnumFactoryConverter : JsonConverterFactory
    {
        private static readonly Type[] ExceptionalEnumTypes = new[] { typeof(ParseMode) };

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum && !ExceptionalEnumTypes.Contains(typeToConvert);

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(SnakeCaseEnumConverter<>).MakeGenericType(typeToConvert);
            return Activator.CreateInstance(converterType) as JsonConverter;
        }
    }
}
