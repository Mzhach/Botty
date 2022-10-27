using Botty.Telegram.Serialization;
using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for classes
    /// </summary>
    internal class ClassFormDataAppender : IFormDataAppender
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToAppend) => typeToAppend.IsClass;

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            formData.Add(new StringContent(TelegramBotClientSerializer.Serialize(value), Encoding.UTF8), name);
        }
    }
}
