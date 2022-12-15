using Botty.Telegram.Abstractions.Types;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for array of InputMedia class
    /// </summary>
    internal class InputMediaArrayFormDataAppender : InputMediaFormDataAppenderBase, IFormDataAppender
    {
        /// <inheritdoc />
        public bool CanAppend(Type typeToAppend) => typeToAppend.IsArray
            && typeToAppend.GetElementType() == typeof(InputMedia);

        /// <inheritdoc />
        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            var inputMedias = value as InputMedia[];

            if (inputMedias == null) throw new ArgumentException("Value is not InputMedia array", nameof(value));

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            writer.WriteStartArray();

            foreach(var inputMedia in inputMedias)
            {
                writer.WriteStartObject();

                switch(inputMedia)
                {
                    case InputMediaPhoto photo:
                        WriteInputMedia(writer, formData, photo);
                        break;
                    case InputMediaVideo video:
                        WriteInputMediaVideo(writer, formData, video);
                        break;
                    case InputMediaAudio audio:
                        WriteInputMediaAudio(writer, formData, audio);
                        break;
                    case InputMediaAnimation animation:
                        WriteInputMediaAnimation(writer, formData, animation);
                        break;
                    case InputMediaDocument document:
                        WriteInputMediaDocument(writer, formData, document);
                        break;
                    default:
                        throw new ArgumentException("Unknown input media type");
                }

                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.Flush();

            var json = Encoding.UTF8.GetString(stream.ToArray());
            formData.Add(new StringContent(json, Encoding.UTF8), name);
        }
    }
}
