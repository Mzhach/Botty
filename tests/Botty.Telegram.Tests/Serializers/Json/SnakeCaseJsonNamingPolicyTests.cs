using AutoFixture;
using Botty.Telegram.Serializers.Json;
using FluentAssertions;
using System.Text.Json;
using Xunit;

namespace Botty.Telegram.Tests.Serializers.Json
{
    public class SnakeCaseJsonNamingPolicyTests
    {
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy()
        };

        public class TestClass
        {
            public string? Name { get; set; }
            public string? ManyWordsInSingleName { get; set; }
        }

        [Fact]
        public void Serializer_ShouldSerializeObjectWithSnakeCaseNaming()
        {
            // Arrange
            var testObject = new TestClass
            {
                Name = _fixture.Create<string>(),
                ManyWordsInSingleName = _fixture.Create<string>()
            };

            // Act
            var serializedTestObject = JsonSerializer.Serialize(testObject, _options);

            // Assert
            var jsonDocument = JsonDocument.Parse(serializedTestObject);

            var nameField = jsonDocument.RootElement.GetProperty("name");
            nameField.GetRawText().Should().Be($"\"{testObject.Name}\"");

            var manyWordsInSingleNameField = jsonDocument.RootElement.GetProperty("many_words_in_single_name");
            manyWordsInSingleNameField.GetRawText().Should().Be($"\"{testObject.ManyWordsInSingleName}\"");
        }

        [Fact]
        public void Serializer_ShouldDeserializeObjectWithSnakeCaseNaming()
        {
            // Arrange
            var nameValue = _fixture.Create<string>();
            var manyWordsInSingleNameValue = _fixture.Create<string>();

            var serializedTestObject = $@"
            {{
                ""name"": ""{nameValue}"",
                ""many_words_in_single_name"": ""{manyWordsInSingleNameValue}""
            }}";

            // Act
            var testObject = JsonSerializer.Deserialize<TestClass>(serializedTestObject, _options);

            // Assert
            testObject.Should().NotBeNull();
            testObject!.Name.Should().Be(nameValue);
            testObject.ManyWordsInSingleName.Should().Be(manyWordsInSingleNameValue);
        }
    }
}