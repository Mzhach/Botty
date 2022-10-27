using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for string
    /// </summary>
    internal class StringFormDataAppender : IFormDataAppender
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToAppend) => typeToAppend == typeof(string);

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            formData.Add(new StringContent(value as string, Encoding.UTF8), name);
        }
    }
}
