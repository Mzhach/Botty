using AutoFixture;
using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;
using Botty.Telegram.Serialization;
using FluentAssertions;
using System.Text.Json;
using Xunit;

namespace Botty.Telegram.Tests.Serialization
{
    public class ReplyMarkupConveterTests
    {
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            Converters = { new ReplyMarkupConverter() }
        };

        [Fact]
        public void Serializer_ShouldSerializeInlineKeyboardMarkup()
        {
            // Arrange
            var keyboard = new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton(_fixture.Create<string>())
                    {
                        CallbackData = _fixture.Create<string>()
                    },
                    new InlineKeyboardButton(_fixture.Create<string>())
                    {
                        Url = _fixture.Create<string>()
                    }
                },
                new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton(_fixture.Create<string>())
                },
                new InlineKeyboardButton[0]
            };

            IReplyMarkup replyMarkup = new InlineKeyboardMarkup(keyboard);

            var expectedJson = $@"{{
  ""inline_keyboard"": [
    [
      {{
        ""text"": ""{keyboard[0][0].Text}"",
        ""callback_data"": ""{keyboard[0][0].CallbackData}""
      }},
      {{
        ""text"": ""{keyboard[0][1].Text}"",
        ""url"": ""{keyboard[0][1].Url}""
      }}
    ],
    [
      {{
        ""text"": ""{keyboard[1][0].Text}""
      }}
    ]
  ]
}}";

            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be(expectedJson);
        }

        [Fact]
        public void Serializer_ShouldSerializeInlineKeyboardMarkupAsNull_IfKeyboardIsEmpty()
        {
            // Arrange
            var emptyKeyboard = new InlineKeyboardButton[0][];
            IReplyMarkup replyMarkup = new InlineKeyboardMarkup(emptyKeyboard);

            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be("null");
        }

        [Fact]
        public void Serializer_ShouldSerializeReplyKeyboardMarkup()
        {
            // Arrange
            var keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton(_fixture.Create<string>()),
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestContact = true
                    }
                },
                new KeyboardButton[]
                {
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestLocation = true
                    },
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestPoll = new KeyboardButtonPollType()
                    },
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestPoll = new KeyboardButtonPollType { Type = PollType.Quiz }
                    }
                },
                new KeyboardButton[0]
            };

            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboard)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true,
                InputFieldPlaceholder = _fixture.Create<string>(),
                Selective = true
            };

            var expectedJson = $@"{{
  ""keyboard"": [
    [
      {{
        ""text"": ""{keyboard[0][0].Text}""
      }},
      {{
        ""text"": ""{keyboard[0][1].Text}"",
        ""request_contact"": true
      }}
    ],
    [
      {{
        ""text"": ""{keyboard[1][0].Text}"",
        ""request_location"": true
      }},
      {{
        ""text"": ""{keyboard[1][1].Text}"",
        ""request_poll"": {{}}
      }},
      {{
        ""text"": ""{keyboard[1][2].Text}"",
        ""request_poll"": {{
          ""type"": ""quiz""
        }}
      }}
    ]
  ],
  ""resize_keyboard"": true,
  ""one_time_keyboard"": true,
  ""input_field_placeholder"": ""{((ReplyKeyboardMarkup)replyMarkup).InputFieldPlaceholder}"",
  ""selective"": true
}}";

            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be(expectedJson);
        }

        [Fact]
        public void Serializer_ShouldSerializeReplyKeyboardMarkupAsNull_IfKeyboardIsEmpty()
        {
            // Arrange
            var emptyKeyboard = new KeyboardButton[0][];
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(emptyKeyboard);

            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be("null");
        }

        [Fact]
        public void Serializer_ShouldSerializeReplyKeyboardRemove()
        {
            // Arrange
            IReplyMarkup replyMarkup = new ReplyKeyboardRemove { Selective = true };

            var expectedJson = @"{
  ""remove_keyboard"": true,
  ""selective"": true
}";
            
            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be(expectedJson);
        }

        [Fact]
        public void Serializer_ShouldSerializeForceReply()
        {
            // Arrange
            IReplyMarkup replyMarkup = new ForceReply
            { 
                InputFieldPlaceholder = _fixture.Create<string>(),
                Selective = true 
            };

            var expectedJson = $@"{{
  ""force_reply"": true,
  ""input_field_placeholder"": ""{((ForceReply)replyMarkup).InputFieldPlaceholder}"",
  ""selective"": true
}}";

            // Act
            var serializedReplyMarkup = JsonSerializer.Serialize(replyMarkup, _options);

            // Assert
            serializedReplyMarkup.Should().Be(expectedJson);
        }
    }
}
