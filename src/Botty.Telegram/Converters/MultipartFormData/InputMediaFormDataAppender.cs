using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Serializers.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for InputMedia class
    /// </summary>
    public class InputMediaFormDataAppender : IFormDataAppender
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

        private void WriteInputMedia(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMedia inputMedia)
        {
            writer.WriteString("type", inputMedia.Type);

            WriteInputFile(writer, formData, "media", inputMedia.Media);

            if (!string.IsNullOrEmpty(inputMedia.Caption))
                writer.WriteString("caption", inputMedia.Caption);

            if (inputMedia.ParseMode.HasValue)
                writer.WriteString("parse_mode", inputMedia.ParseMode.ToString());

            if (inputMedia.CaptionEntities != null)
            {
                writer.WritePropertyName("caption_entities");
                writer.WriteRawValue(TelegramBotClientJsonSerializer.Serialize(inputMedia.CaptionEntities));
            }
        }

        private void WriteInputMediaVideo(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaVideo video)
        {
            WriteInputMedia(writer, formData, video);

            if (video.Thumb != null)
                WriteInputFile(writer, formData, "thumb", video.Thumb);

            if (video.Width.HasValue)
                writer.WriteNumber("width", video.Width.Value);

            if (video.Height.HasValue)
                writer.WriteNumber("height", video.Height.Value);

            if (video.Duration.HasValue)
                writer.WriteNumber("duration", video.Duration.Value);

            if (video.SupportsStreaming.HasValue)
                writer.WriteBoolean("supports_streaming", video.SupportsStreaming.Value);
        }

        private void WriteInputMediaAudio(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaAudio audio)
        {
            WriteInputMedia(writer, formData, audio);

            if (audio.Thumb != null)
                WriteInputFile(writer, formData, "thumb", audio.Thumb);

            if (audio.Duration.HasValue)
                writer.WriteNumber("duration", audio.Duration.Value);

            if (!string.IsNullOrEmpty(audio.Performer))
                writer.WriteString("performer", audio.Performer);

            if (!string.IsNullOrEmpty(audio.Title))
                writer.WriteString("title", audio.Title);
        }

        private void WriteInputMediaAnimation(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaAnimation animation)
        {
            WriteInputMedia(writer, formData, animation);

            if (animation.Thumb != null)
                WriteInputFile(writer, formData, "thumb", animation.Thumb);

            if (animation.Width.HasValue)
                writer.WriteNumber("width", animation.Width.Value);

            if (animation.Height.HasValue)
                writer.WriteNumber("height", animation.Height.Value);

            if (animation.Duration.HasValue)
                writer.WriteNumber("duration", animation.Duration.Value);
        }

        private void WriteInputMediaDocument(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaDocument document)
        {
            WriteInputMedia(writer, formData, document);

            if (document.Thumb != null)
                WriteInputFile(writer, formData, "thumb", document.Thumb);

            if (document.DisableContentTypeDetection.HasValue)
                writer.WriteBoolean("disable_content_type_detection", document.DisableContentTypeDetection.Value);
        }

        private void WriteInputFile(Utf8JsonWriter writer, MultipartFormDataContent formData, string propertyName, InputFile inputFile)
        {
            if (!string.IsNullOrEmpty(inputFile.FileId))
                writer.WriteString(propertyName, inputFile.FileId);

            if (inputFile.Url != null)
                writer.WriteString(propertyName, inputFile.Url.ToString());

            if (!string.IsNullOrEmpty(inputFile.Filename) && inputFile.FileContent != null)
            {
                var attachName = Guid.NewGuid().ToString();
                writer.WriteString(propertyName, $"attach://{attachName}");
                formData.Add(new StreamContent(inputFile.FileContent), attachName, inputFile.Filename);
            }
        }
    }
}
