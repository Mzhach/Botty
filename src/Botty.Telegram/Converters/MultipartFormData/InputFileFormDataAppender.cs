using Botty.Telegram.Abstractions.Types;
using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for InputFile class
    /// </summary>
    internal class InputFileFormDataAppender : IFormDataAppender
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToAppend) => typeToAppend == typeof(InputFile);

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            var inputFile = value as InputFile;

            if (!string.IsNullOrEmpty(inputFile!.FileId))
            {
                formData.Add(new StringContent(inputFile.FileId, Encoding.UTF8), name);
                return;
            }

            if (inputFile!.Url != null)
            {
                formData.Add(new StringContent(inputFile.Url.ToString(), Encoding.UTF8), name);
                return;
            }

            formData.Add(new StreamContent(inputFile!.FileContent), name, inputFile.Filename);
        }
    }
}
