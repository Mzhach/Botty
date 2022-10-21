using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Extensions;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Botty.Telegram.Serialization
{
    /// <summary>
    /// Converter for reply markups
    /// </summary>
    public class ReplyMarkupConverter : JsonConverter<IReplyMarkup>
    {
        /// <inheritdoc />
        public override IReplyMarkup? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotImplementedException();

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, IReplyMarkup value, JsonSerializerOptions options)
        {
            if (value is InlineKeyboardMarkup inlineKeyboardMarkup)
            {
                WriteInlineKeyboardMarkup(writer, inlineKeyboardMarkup);
                return;
            }

            if (value is ReplyKeyboardMarkup replyKeyboardMarkup)
            {
                WriteReplyKeyboardMarkup(writer, replyKeyboardMarkup);
                return;
            }

            if (value is ReplyKeyboardRemove replyKeyboardRemove)
            {
                WriteReplyKeyboardRemove(writer, replyKeyboardRemove);
                return;
            }

            if (value is ForceReply forceReply)
            {
                WriteForceReply(writer, forceReply);
                return;
            }

            throw new JsonException($"Unsupported reply markup");
        }

        private void WriteInlineKeyboardMarkup(Utf8JsonWriter writer, InlineKeyboardMarkup value)
        {
            if (value.InlineKeyboard is null || value.InlineKeyboard.Length == 0)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();
            writer.WriteStartArray("inline_keyboard");

            foreach(var rowButtons in value.InlineKeyboard)
            {
                if (rowButtons.Length == 0) continue;

                writer.WriteStartArray();

                foreach (var button in rowButtons)
                {
                    writer.WriteStartObject();

                    writer.WriteString("text", button.Text);

                    if (!string.IsNullOrEmpty(button.Url))
                        writer.WriteString("url", button.Url);

                    if (!string.IsNullOrEmpty(button.CallbackData))
                        writer.WriteString("callback_data", button.CallbackData);

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private void WriteReplyKeyboardMarkup(Utf8JsonWriter writer, ReplyKeyboardMarkup value)
        {
            if (value.Keyboard is null || value.Keyboard.Length == 0)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();
            writer.WriteStartArray("keyboard");

            foreach (var rowButtons in value.Keyboard)
            {
                if (rowButtons.Length == 0) continue;

                writer.WriteStartArray();

                foreach (var button in rowButtons)
                {
                    writer.WriteStartObject();
                    writer.WriteString("text", button.Text);

                    if (button.RequestContact.HasValue)
                        writer.WriteBoolean("request_contact", button.RequestContact.Value);

                    if (button.RequestLocation.HasValue)
                        writer.WriteBoolean("request_location", button.RequestLocation.Value);

                    if (button.RequestPoll != null)
                    {
                        writer.WritePropertyName("request_poll");
                        writer.WriteStartObject();

                        if (button.RequestPoll.Type.HasValue)
                        {
                            var typeValue = button.RequestPoll.Type.ToString().ToSnakeCase();
                            writer.WriteString("type", typeValue);
                        }

                        writer.WriteEndObject();
                    }

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();

            if (value.ResizeKeyboard.HasValue)
                writer.WriteBoolean("resize_keyboard", value.ResizeKeyboard.Value);

            if (value.OneTimeKeyboard.HasValue)
                writer.WriteBoolean("one_time_keyboard", value.OneTimeKeyboard.Value);

            if (!string.IsNullOrEmpty(value.InputFieldPlaceholder))
                writer.WriteString("input_field_placeholder", value.InputFieldPlaceholder);

            if (value.Selective.HasValue)
                writer.WriteBoolean("selective", value.Selective.Value);

            writer.WriteEndObject();
        }

        private void WriteReplyKeyboardRemove(Utf8JsonWriter writer, ReplyKeyboardRemove value)
        {
            writer.WriteStartObject();

            writer.WriteBoolean("remove_keyboard", true);

            if (value.Selective.HasValue)
                writer.WriteBoolean("selective", value.Selective.Value);

            writer.WriteEndObject();
        }

        private void WriteForceReply(Utf8JsonWriter writer, ForceReply value)
        {
            writer.WriteStartObject();

            writer.WriteBoolean("force_reply", true);

            if (!string.IsNullOrEmpty(value.InputFieldPlaceholder))
                writer.WriteString("input_field_placeholder", value.InputFieldPlaceholder);

            if (value.Selective.HasValue)
                writer.WriteBoolean("selective", value.Selective.Value);

            writer.WriteEndObject();
        }
    }
}
