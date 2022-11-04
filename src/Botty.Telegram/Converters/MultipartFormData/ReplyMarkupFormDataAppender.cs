using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Serializers.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Botty.Telegram.Converters.MultipartFormData
{
    /// <summary>
    /// Appender for reply markup
    /// </summary>
    internal class ReplyMarkupFormDataAppender : IFormDataAppender
    {
        public bool CanAppend(Type typeToAppend) => typeToAppend.IsAssignableFrom(typeof(IReplyMarkup));

        public void Append(MultipartFormDataContent formData, object value, string name, Type typeToAppend)
        {
            if (value is null) return;

            formData.Add(new StringContent(TelegramBotClientJsonSerializer.Serialize(value, typeof(IReplyMarkup)), Encoding.UTF8), name);
        }
    }
}
