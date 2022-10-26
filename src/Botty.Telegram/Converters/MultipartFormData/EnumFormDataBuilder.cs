using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Conveter for enums
    /// </summary>
    internal class EnumFormDataBuilder : IFormDataBuilder
    {
        private static readonly Type[] ExceptionalEnumTypes = new[] { typeof(ParseMode) };

        /// <inheritdoc />
        public bool CanAppend(Type typeToConvert) 
            => typeToConvert.IsEnum
            || typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Nullable<>)
            && Nullable.GetUnderlyingType(typeToConvert).IsEnum;

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert)
        {
            if (value is null) return;

            StringContent content;
            if (ExceptionalEnumTypes.Contains(GetTypeOrUnderlyingType(typeToConvert)))
                content = new StringContent(value.ToString(), Encoding.UTF8);
            else
                content = new StringContent(value.ToString().ToSnakeCase(), Encoding.UTF8);

            formData.Add(content, name);
        }

        private Type GetTypeOrUnderlyingType(Type type)
        {
            if (!type.IsGenericType)
                return type;

            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return Nullable.GetUnderlyingType(type);

            throw new ArgumentException("Type is not nullable type");
        }
    }
}
