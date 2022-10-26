using System;
using System.Net.Http;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appends data to FormData
    /// </summary>
    public interface IFormDataBuilder
    {
        /// <summary>
        /// Check if builder can append type
        /// </summary>
        /// <param name="typeToConvert">The type to convertion</param>
        /// <returns>True if type could be converted</returns>
        bool CanAppend(Type typeToConvert);

        /// <summary>
        /// Appends data to FormData
        /// </summary>
        /// <param name="formData">Form data</param>
        /// <param name="value">Value to be converted</param>
        /// <param name="name">Value to be converted</param>
        /// <param name="typeToConvert">The type to convertion</param>
        /// <returns>Converted HttpContent or null if value is null</returns>
        void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert);
    }
}
