using Botty.Telegram.Abstractions.Types;
using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Converter for InputFile class
    /// </summary>
    internal class InputFileFormDataBuilder : IFormDataBuilder
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToConvert) => typeToConvert == typeof(InputFile);

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToConvert)
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
