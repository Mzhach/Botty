using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Converter for primitive types
    /// </summary>
    internal class PrimitiveTypesFormDataBuilder : IFormDataBuilder
    {
        private static readonly Type[] SupportedTypes = new[]
        {
            typeof(bool),
            typeof(int),
            typeof(long)
        };

        /// <inheritdoc />
        public bool CanAppend(Type typeToConvert) 
            => SupportedTypes.Contains(typeToConvert) 
            || typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>)
            && SupportedTypes.Contains(Nullable.GetUnderlyingType(typeToConvert));

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert)
        {
            if (value is null) return;

            formData.Add(new StringContent(value.ToString(), Encoding.UTF8), name);
        }
    }
}
