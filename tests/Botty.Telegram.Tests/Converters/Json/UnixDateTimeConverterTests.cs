using AutoFixture;
using Botty.Telegram.Converters.Json;
using FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace Botty.Telegram.Tests.Converters.Json
{
    public class UnixDateTimeConverterTests
    {
        private readonly Fixture _fixture = new();
        private readonly JsonSerializerOptions _options = new()
        {
            Converters = { new UnixDateTimeConverter() }
        };

        public class TestClass
        {
            public DateTime DateTime { get; set; }
        }

        [Fact]
        public void Serializer_ShouldDeserializeDateTimeFromUnixTimestamp()
        {
            // Arrange
            var serializedTestObject = @"{""DateTime"": 1666119634}";

            // Act
            var testObject = JsonSerializer.Deserialize<TestClass>(serializedTestObject, _options);

            // Assert
            testObject.Should().NotBeNull();
            testObject!.DateTime.Should().Be(new DateTime(2022, 10, 18, 19, 00, 34, DateTimeKind.Utc));
        }

        [Fact]
        public void Serializer_ShouldSerializeDateTimeToUnixTimestamp()
        {
            // Arrange
            var testObject = _fixture
                .Build<TestClass>()
                .Create();

            var expected = ((DateTimeOffset)testObject.DateTime).ToUnixTimeSeconds();

            // Act
            var serializedTestObject = JsonSerializer.Serialize(testObject, _options);

            // Assert
            serializedTestObject.Should().NotBeNullOrEmpty();
            var jsonDocument = JsonDocument.Parse(serializedTestObject);
            var dateTimeProperty = jsonDocument.RootElement.GetProperty(nameof(TestClass.DateTime));
            dateTimeProperty.GetInt64().Should().Be(expected);
        }
    }
}
