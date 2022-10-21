using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Serialization;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace Botty.Telegram.Tests.Serialization
{
    public class SnakeCaseEnumFactoryConverterTests
    {
        private readonly JsonSerializerOptions _options = new()
        {
            Converters = { new SnakeCaseEnumFactoryConverter() }
        };

        public class TestClass<TEnum>
            where TEnum : struct
        {
            public TEnum Value { get; set; }
        }

        public static IEnumerable<object[]> TestCases =>
            new List<object[]>
            {
                new object[] {typeof(ChatType), ChatType.Private},
                new object[] {typeof(ChatType), ChatType.Group},
                new object[] {typeof(ChatType), ChatType.Supergroup},
                new object[] {typeof(ChatType), ChatType.Channel},
                new object[] {typeof(MessageEntityType), MessageEntityType.Mention},
                new object[] {typeof(MessageEntityType), MessageEntityType.Hashtag},
                new object[] {typeof(MessageEntityType), MessageEntityType.Cashtag},
                new object[] {typeof(MessageEntityType), MessageEntityType.BotCommand},
                new object[] {typeof(MessageEntityType), MessageEntityType.Url},
                new object[] {typeof(MessageEntityType), MessageEntityType.Email},
                new object[] {typeof(MessageEntityType), MessageEntityType.PhoneNumber},
                new object[] {typeof(MessageEntityType), MessageEntityType.Bold},
                new object[] {typeof(MessageEntityType), MessageEntityType.Italic},
                new object[] {typeof(MessageEntityType), MessageEntityType.Underline},
                new object[] {typeof(MessageEntityType), MessageEntityType.Strikethrough},
                new object[] {typeof(MessageEntityType), MessageEntityType.Spoiler},
                new object[] {typeof(MessageEntityType), MessageEntityType.Code},
                new object[] {typeof(MessageEntityType), MessageEntityType.Pre},
                new object[] {typeof(MessageEntityType), MessageEntityType.TextLink},
                new object[] {typeof(MessageEntityType), MessageEntityType.TextMention},
                new object[] {typeof(MessageEntityType), MessageEntityType.CustomEmoji},
                new object[] {typeof(UpdateType), UpdateType.Message},
                new object[] {typeof(UpdateType), UpdateType.EditedMessage},
                new object[] {typeof(UpdateType), UpdateType.ChannelPost},
                new object[] {typeof(UpdateType), UpdateType.EditedChannelPost},
                new object[] {typeof(UpdateType), UpdateType.InlineQuery},
                new object[] {typeof(UpdateType), UpdateType.ChosenInlineResult},
                new object[] {typeof(UpdateType), UpdateType.CallbackQuery},
                new object[] {typeof(UpdateType), UpdateType.ShippingQuery},
                new object[] {typeof(UpdateType), UpdateType.PreCheckoutQuery},
                new object[] {typeof(UpdateType), UpdateType.Poll},
                new object[] {typeof(UpdateType), UpdateType.PollAnswer},
                new object[] {typeof(UpdateType), UpdateType.MyChatMember},
                new object[] {typeof(UpdateType), UpdateType.ChatMember},
                new object[] {typeof(UpdateType), UpdateType.ChatJoinRequest},

            };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Serializer_ShouldDeserializeEnumValue(Type enumType, object enumValue)
        {
            // Arrange
            var testClassType = typeof(TestClass<>).MakeGenericType(enumType);
            var valueGetter = testClassType.GetProperty("Value")!.GetGetMethod();
            var snakeCaseValue = SnakeCaseJsonNamingPolicy.ToSnakeCase(enumValue.ToString()!);
            var serializedTestObject = $@"{{""Value"": ""{snakeCaseValue}""}}";

            // Act
            var testObject = JsonSerializer.Deserialize(serializedTestObject, testClassType, _options);

            // Assert
            testObject.Should().NotBeNull();
            valueGetter!.Invoke(testObject, null).Should().Be(enumValue);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Serializer_ShouldSerializeEnumValue(Type enumType, object enumValue)
        {
            // Arrange
            var testClassType = typeof(TestClass<>).MakeGenericType(enumType);
            var testObject = Activator.CreateInstance(testClassType);
            var snakeCaseValue = SnakeCaseJsonNamingPolicy.ToSnakeCase(enumValue.ToString()!);

            var valueSetter = testClassType.GetProperty("Value")!.GetSetMethod();
            valueSetter!.Invoke(testObject, new object[] { enumValue });

            // Act
            var serializedTestObject = JsonSerializer.Serialize(testObject, testClassType, _options);

            // Assert
            serializedTestObject.Should().NotBeEmpty();
            var jsonDocument = JsonDocument.Parse(serializedTestObject);

            jsonDocument.RootElement.GetProperty("Value").GetString().Should().Be(snakeCaseValue);
        }
    }
}
