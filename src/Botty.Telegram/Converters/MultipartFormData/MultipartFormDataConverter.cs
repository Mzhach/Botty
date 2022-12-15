using Botty.Telegram.Abstractions.Exceptions;
using Botty.Telegram.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Converter from object to MultipleFormDataContent
    /// </summary>
    public static class MultipartFormDataConverter
    {
        /// <summary>
        /// Form data appenders
        /// </summary>
        public static IList<IFormDataAppender> Appenders { get; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static MultipartFormDataConverter()
        {
            Appenders = new List<IFormDataAppender>
            {
                new PrimitiveTypesFormDataAppender(),
                new EnumFormDataAppender(),
                new StringFormDataAppender(),
                new InputFileFormDataAppender(),
                new ReplyMarkupFormDataAppender(),
                new InputMediaFormDataAppender(),
                new InputMediaArrayFormDataAppender(),
                new ClassFormDataAppender()
            };
        }

        /// <summary>
        /// Converts object to MultipartFormDataContent
        /// </summary>
        /// <param name="objectToConvert">Object to convert</param>
        /// <returns>Converted MultipartFormDataContent</returns>
        public static MultipartFormDataContent Convert(object objectToConvert)
        {
            if (objectToConvert is null) throw new ArgumentNullException(nameof(objectToConvert));

            var type = objectToConvert.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

            var formData = new MultipartFormDataContent();

            foreach (var property in properties)
            {
                var value = property.GetValue(objectToConvert);

                var propertyAppended = false;
                foreach (var builder in Appenders)
                {
                    if (builder.CanAppend(property.PropertyType))
                    {
                        builder.Append(formData, value, property.Name.ToSnakeCase(), property.PropertyType);
                        propertyAppended = true;
                        break;
                    }
                }

                if(!propertyAppended)
                    throw new TelegramBotClientException($"No appender was found for '{property.Name}' property");
            }

            return formData;
        }
    }
}
