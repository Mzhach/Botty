using Botty.Telegram.Serialization;
using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Converter for classes
    /// </summary>
    internal class ClassFormDataBuilder : IFormDataBuilder
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToConvert) => typeToConvert.IsClass;

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert)
        {
            if (value is null) return;

            formData.Add(new StringContent(TelegramBotClientSerializer.Serialize(value), Encoding.UTF8), name);
        }
    }
}
