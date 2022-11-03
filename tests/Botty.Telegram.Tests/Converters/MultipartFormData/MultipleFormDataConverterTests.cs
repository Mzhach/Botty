using AutoFixture;
using Botty.Telegram.Extensions;
using Botty.Telegram.Converters.MultipartFormData;
using Botty.Telegram.Tests.FluentAssertionExtensions;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;
using System;
using System.IO;

namespace Botty.Telegram.Tests.Converters.MultipartFormData
{
    public class MultipleFormDataConverterTests
    {
        private readonly Fixture _fixture = new();

        public class TestClassWithPrimitiveTypes
        {
            public bool BoolValue { get; set; }
            public bool? NullableBoolValue { get; set; }
            public int IntValue { get; set; }
            public int? NullableIntValue { get; set; }
            public long LongValue { get; set; }
            public long? NullableLongValue { get; set; }
            public string? StringValue { get; set; }
            public ParseMode ParseMode { get; set; }
            public ParseMode? NullableParseMode { get; set; }
            public UpdateType UpdateType { get; set; }
            public UpdateType? NullableUpdateType { get; set; }
        }

        [Fact]
        public async Task Converter_ShouldConvertPrimitiveProperties()
        {
            // Arrange
            var testObject = _fixture
                .Build<TestClassWithPrimitiveTypes>()
                .With(x => x.ParseMode, ParseMode.MarkdownV2)
                .With(x => x.NullableParseMode, ParseMode.HTML)
                .With(x => x.UpdateType, UpdateType.CallbackQuery)
                .With(x => x.NullableUpdateType, UpdateType.EditedMessage)
                .Create();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.BoolValue).ToSnakeCase(), testObject.BoolValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.NullableBoolValue).ToSnakeCase(), testObject.NullableBoolValue.ToString()!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.IntValue).ToSnakeCase(), testObject.IntValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.NullableIntValue).ToSnakeCase(), testObject.NullableIntValue.ToString()!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.LongValue).ToSnakeCase(), testObject.LongValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.NullableLongValue).ToSnakeCase(), testObject.NullableLongValue.ToString()!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.StringValue).ToSnakeCase(), testObject.StringValue!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.ParseMode).ToSnakeCase(), testObject.ParseMode.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.NullableParseMode).ToSnakeCase(), testObject.NullableParseMode.ToString()!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.UpdateType).ToSnakeCase(), testObject.UpdateType.ToString().ToSnakeCase());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.NullableUpdateType).ToSnakeCase(), testObject.NullableUpdateType.ToString()!.ToSnakeCase());
        }

        [Fact]
        public async Task Converter_ShouldNotConvertNullPrimitiveProperties()
        {
            // Arrange
            var testObject = _fixture
                .Build<TestClassWithPrimitiveTypes>()
                .With(x => x.ParseMode, ParseMode.MarkdownV2)
                .With(x => x.UpdateType, UpdateType.CallbackQuery)
                .Without(x => x.NullableBoolValue)
                .Without(x => x.NullableIntValue)
                .Without(x => x.NullableLongValue)
                .Without(x => x.NullableParseMode)
                .Without(x => x.NullableUpdateType)
                .Create();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert

            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.BoolValue).ToSnakeCase(), testObject.BoolValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.IntValue).ToSnakeCase(), testObject.IntValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.LongValue).ToSnakeCase(), testObject.LongValue.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.StringValue).ToSnakeCase(), testObject.StringValue!);
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.ParseMode).ToSnakeCase(), testObject.ParseMode.ToString());
            await formData.Should().ContainAsync(nameof(TestClassWithPrimitiveTypes.UpdateType).ToSnakeCase(), testObject.UpdateType.ToString().ToSnakeCase());

            formData.Should().NotContain(nameof(TestClassWithPrimitiveTypes.NullableBoolValue).ToSnakeCase());
            formData.Should().NotContain(nameof(TestClassWithPrimitiveTypes.NullableIntValue).ToSnakeCase());
            formData.Should().NotContain(nameof(TestClassWithPrimitiveTypes.NullableLongValue).ToSnakeCase());
            formData.Should().NotContain(nameof(TestClassWithPrimitiveTypes.NullableParseMode).ToSnakeCase());
            formData.Should().NotContain(nameof(TestClassWithPrimitiveTypes.NullableUpdateType).ToSnakeCase());
        }

        public class TestClassNestedNestedObject
        {
            public string? Value { get; set; }
        }

        public class TestClassNestedObject
        {
            public string? Value { get; set; }
            public TestClassNestedNestedObject? NestedObject { get; set; }
            public TestClassNestedNestedObject[]? NestedObjects { get; set; }
        }

        public class TestClassWithNestedObjects
        {
            public TestClassNestedObject? NestedObject { get; set; }
            public TestClassNestedObject[]? NestedObjects { get; set; }
        }

        [Fact]
        public async Task Converter_ShouldConvertNestedObjectsAsJson()
        {
            // Arrange
            var testObject = _fixture
                .Build<TestClassWithNestedObjects>()
                .Create();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithNestedObjects.NestedObject).ToSnakeCase(), testObject.NestedObject);
            await formData.Should().ContainAsync(nameof(TestClassWithNestedObjects.NestedObjects).ToSnakeCase(), testObject.NestedObjects);
        }

        [Fact]
        public async Task Converter_ShouldNotConvertNullNestedObjects()
        {
            // Arrange
            var testObject = _fixture
                .Build<TestClassWithNestedObjects>()
                .Without(x => x.NestedObject)
                .Create();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            formData.Should().NotContain(nameof(TestClassWithNestedObjects.NestedObject).ToSnakeCase());
            await formData.Should().ContainAsync(nameof(TestClassWithNestedObjects.NestedObjects).ToSnakeCase(), testObject.NestedObjects);
        }

        public class TestClassWithInputFile
        {
            public InputFile? InputFile { get; set; }
        }

        [Fact]
        public async Task Converter_ShouldConvertInputFileAsFileId()
        {
            // Arrange
            var inputFile = new InputFile(_fixture.Create<string>());
            var testObject = new TestClassWithInputFile { InputFile = inputFile };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithInputFile.InputFile).ToSnakeCase(), testObject.InputFile.FileId!);
        }

        [Fact]
        public async Task Converter_ShouldConvertInputFileAsUrl()
        {
            // Arrange
            var inputFile = new InputFile(_fixture.Create<Uri>());
            var testObject = new TestClassWithInputFile { InputFile = inputFile };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithInputFile.InputFile).ToSnakeCase(), testObject.InputFile.Url!.ToString());
        }

        [Fact]
        public async Task Converter_ShouldConvertInputFileAsStream()
        {
            // Arrange
            var inputFile = new InputFile(_fixture.Create<string>(), new MemoryStream(new byte[] { 1, 2, 3 }));
            var testObject = new TestClassWithInputFile { InputFile = inputFile };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainFileAsync(
                nameof(TestClassWithInputFile.InputFile).ToSnakeCase(),
                inputFile.Filename!,
                inputFile.FileContent!);
        }

        [Fact]
        public void Converter_ShouldNotConvertNullInputFile()
        {
            // Arrange
            var testObject = new TestClassWithInputFile();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            formData.Should().NotContain(nameof(TestClassWithInputFile.InputFile).ToSnakeCase());
        }

        public class TestClassWithReplyMarkup
        {
            public IReplyMarkup? ReplyMarkup { get; set; }
        }

        [Fact]
        public async Task Converter_ShouldConvertInlineKeyboardMarkup()
        {
            // Arrange
            var inlineKeyboard = new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton(_fixture.Create<string>(), url: _fixture.Create<string>()),
                    new InlineKeyboardButton(_fixture.Create<string>(), callbackData: _fixture.Create<string>())
                }
            };

            var inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboard);
            var testObject = new TestClassWithReplyMarkup { ReplyMarkup = inlineKeyboardMarkup };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithReplyMarkup.ReplyMarkup).ToSnakeCase(), inlineKeyboardMarkup);
        }

        [Fact]
        public async Task Converter_ShouldConvertReplyKeyboardMarkup()
        {
            // Arrange
            var keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
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
                    }
                },
                new KeyboardButton[]
                {
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestPoll = new KeyboardButtonPollType()
                    }
                },
                new KeyboardButton[]
                {
                    new KeyboardButton(_fixture.Create<string>())
                    {
                        RequestPoll = new KeyboardButtonPollType { Type = PollType.Regular }
                    }
                }
            };

            var replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboard)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true,
                InputFieldPlaceholder = _fixture.Create<string>(),
                Selective = true
            };

            var testObject = new TestClassWithReplyMarkup { ReplyMarkup = replyKeyboardMarkup };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithReplyMarkup.ReplyMarkup).ToSnakeCase(), replyKeyboardMarkup);
        }

        [Fact]
        public async Task Converter_ShouldConvertForceReply()
        {
            // Arrange
            var forceReply = new ForceReply
            {
                InputFieldPlaceholder = _fixture.Create<string>(),
                Selective = true
            };

            var testObject = new TestClassWithReplyMarkup { ReplyMarkup = forceReply };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithReplyMarkup.ReplyMarkup).ToSnakeCase(), forceReply);
        }

        [Fact]
        public async Task Converter_ShouldConvertReplyKeyboardRemove()
        {
            // Arrange
            var replyKeyboardRemove = new ReplyKeyboardRemove { Selective = true };
            var testObject = new TestClassWithReplyMarkup { ReplyMarkup = replyKeyboardRemove };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            await formData.Should().ContainAsync(nameof(TestClassWithReplyMarkup.ReplyMarkup).ToSnakeCase(), replyKeyboardRemove);
        }

        [Fact]
        public void Converter_ShouldNotConvertNullReplyMarkup()
        {
            // Arrange
            var testObject = new TestClassWithReplyMarkup { ReplyMarkup = null };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            formData.Should().NotContain(nameof(TestClassWithReplyMarkup.ReplyMarkup).ToSnakeCase());
        }
    }
}
