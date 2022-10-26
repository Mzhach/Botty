using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Converter for string
    /// </summary>
    internal class StringFormDataBuilder : IFormDataBuilder
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToConvert) => typeToConvert == typeof(string);

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert)
        {
            if (value is null) return;

            formData.Add(new StringContent(value as string, Encoding.UTF8), name);
        }
    }
}
