using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for primitive types
    /// </summary>
    internal class PrimitiveTypesFormDataAppender : IFormDataAppender
    {
        private static readonly Type[] SupportedTypes = new[]
        {
            typeof(bool),
            typeof(int),
            typeof(long)
        };

        /// <inheritdoc />
        public bool CanAppend(Type typeToAppend) 
            => SupportedTypes.Contains(typeToAppend) 
            || typeToAppend.IsGenericType
            && typeToAppend.GetGenericTypeDefinition() == typeof(Nullable<>)
            && SupportedTypes.Contains(Nullable.GetUnderlyingType(typeToAppend));

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            formData.Add(new StringContent(value.ToString(), Encoding.UTF8), name);
        }
    }
}
