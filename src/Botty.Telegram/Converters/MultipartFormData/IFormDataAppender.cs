using System;
using System.Net.Http;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appends data to FormData
    /// </summary>
    public interface IFormDataAppender
    {
        /// <summary>
        /// Check if builder can append type
        /// </summary>
        /// <param name="typeToAppend">The type to append</param>
        /// <returns>True if type could be appended</returns>
        bool CanAppend(Type typeToAppend);

        /// <summary>
        /// Appends data to FormData
        /// </summary>
        /// <param name="formData">Form data</param>
        /// <param name="value">Value to be appended</param>
        /// <param name="name">Field name</param>
        /// <param name="typeToAppend">The type to append</param>
        void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend);
    }
}
