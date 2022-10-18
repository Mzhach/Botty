using Botty.Telegram.Serialization;
using FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace Botty.Telegram.Tests.Serialization
{
    public class UnixDateTimeConverterTests
    {
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
    }
}
