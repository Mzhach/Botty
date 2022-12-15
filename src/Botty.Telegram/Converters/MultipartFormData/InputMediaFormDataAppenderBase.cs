using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Serializers.Json;
using System;
using System.Net.Http;
using System.Text.Json;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Base class for input media form data appender
    /// </summary>
    public abstract class InputMediaFormDataAppenderBase
    {
        protected void WriteInputMedia(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMedia inputMedia)
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

        protected void WriteInputMediaVideo(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaVideo video)
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

        protected void WriteInputMediaAudio(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaAudio audio)
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

        protected void WriteInputMediaAnimation(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaAnimation animation)
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

        protected void WriteInputMediaDocument(Utf8JsonWriter writer, MultipartFormDataContent formData, InputMediaDocument document)
        {
            WriteInputMedia(writer, formData, document);

            if (document.Thumb != null)
                WriteInputFile(writer, formData, "thumb", document.Thumb);

            if (document.DisableContentTypeDetection.HasValue)
                writer.WriteBoolean("disable_content_type_detection", document.DisableContentTypeDetection.Value);
        }

        protected void WriteInputFile(Utf8JsonWriter writer, MultipartFormDataContent formData, string propertyName, InputFile inputFile)
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
