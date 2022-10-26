using AutoFixture;
using Botty.Telegram.Extensions;
using Botty.Telegram.Converters.MultipartFormData;
using Botty.Telegram.Serialization;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Botty.Telegram.Abstractions.Enums;
using Botty.Telegram.Abstractions.Types;
using System;
using System.IO;
using System.Text;

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
            formData.Should().NotBeNull();
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.BoolValue), testObject.BoolValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableBoolValue), testObject.NullableBoolValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.IntValue), testObject.IntValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableIntValue), testObject.NullableIntValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.LongValue), testObject.LongValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableLongValue), testObject.NullableLongValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.StringValue), testObject.StringValue);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.ParseMode), testObject.ParseMode.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableParseMode), testObject.NullableParseMode.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.UpdateType), testObject.UpdateType.ToString().ToSnakeCase());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableUpdateType), testObject.NullableUpdateType.ToString()!.ToSnakeCase());
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
            formData.Should().NotBeNull();
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.BoolValue), testObject.BoolValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableBoolValue), null);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.IntValue), testObject.IntValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableIntValue), null);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.LongValue), testObject.LongValue.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableLongValue), null);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.StringValue), testObject.StringValue);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.ParseMode), testObject.ParseMode.ToString());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableParseMode), null);
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.UpdateType), testObject.UpdateType.ToString().ToSnakeCase());
            await CheckPrimitiveType(formData, nameof(TestClassWithPrimitiveTypes.NullableUpdateType), null);
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
            formData.Should().NotBeNull();
            await CheckNestedObject(formData, nameof(TestClassWithNestedObjects.NestedObject), testObject.NestedObject);
            await CheckNestedObject(formData, nameof(TestClassWithNestedObjects.NestedObjects), testObject.NestedObjects);
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
            formData.Should().NotBeNull();
            await CheckNestedObject(formData, nameof(TestClassWithNestedObjects.NestedObject), testObject.NestedObject);
            await CheckNestedObject(formData, nameof(TestClassWithNestedObjects.NestedObjects), testObject.NestedObjects);
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
            formData.Should().NotBeNull();
            await CheckPrimitiveType(formData, nameof(TestClassWithInputFile.InputFile), testObject.InputFile.FileId);
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
            formData.Should().NotBeNull();
            await CheckPrimitiveType(formData, nameof(TestClassWithInputFile.InputFile), testObject.InputFile.Url!.ToString());
        }

        [Fact]
        public async Task Converter_ShouldConvertInputFileAsStream()
        {
            // Arrange
            var bytes = _fixture.Create<byte[]>();
            var expectedContent = Encoding.UTF8.GetString(bytes);

            var inputFile = new InputFile(_fixture.Create<string>(), new MemoryStream(bytes));
            var testObject = new TestClassWithInputFile { InputFile = inputFile };

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            formData.Should().NotBeNull();

            var httpContent = GetHttpContent(formData, nameof(TestClassWithInputFile.InputFile).ToSnakeCase());
            httpContent.Headers.ContentDisposition!.FileName.Should().Be(inputFile.Filename);

            var content = await httpContent.ReadAsStringAsync();
            content.Should().Be(expectedContent);
        }

        [Fact]
        public async Task Converter_ShouldNotConvertNullInputFile()
        {
            // Arrange
            var testObject = new TestClassWithInputFile();

            // Act
            var formData = MultipartFormDataConverter.Convert(testObject);

            // Assert
            formData.Should().NotBeNull();
            await CheckPrimitiveType(formData, nameof(TestClassWithInputFile.InputFile), null);
        }

        private async Task CheckNestedObject<T>(MultipartFormDataContent formData, string name, T? expected)
            where T : class
        {
            if (expected is null)
            {
                CheckEmptyHttpContent(formData, name.ToSnakeCase());
                return;
            }

            var httpContent = GetHttpContent(formData, name.ToSnakeCase());
            var content = await httpContent.ReadAsStringAsync();
            var exptected = TelegramBotClientSerializer.Serialize(expected);

            content.Should().Be(exptected);
        }

        private async Task CheckPrimitiveType(
            MultipartFormDataContent formData,
            string name,
            string? expected = default)
        {
            if (expected is null)
            {
                CheckEmptyHttpContent(formData, name.ToSnakeCase());
                return;
            }

            var httpContent = GetHttpContent(formData, name.ToSnakeCase());
            var content = await httpContent.ReadAsStringAsync();

            content.Should().Be(expected);
        }

        private void CheckEmptyHttpContent(MultipartFormDataContent formData, string name)
            => formData.Should()
                    .NotContain(x => x.Headers.ContentDisposition != null
                                     && x.Headers.ContentDisposition.Name == name);

        private HttpContent GetHttpContent(MultipartFormDataContent formData, string name)
            => formData.Should()
                .ContainSingle(x => x.Headers.ContentDisposition != null
                                    && x.Headers.ContentDisposition.Name == name)
                .Which;
    }
}
