using Botty.Telegram.Extensions;
using FluentAssertions;
using Xunit;

namespace Botty.Telegram.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Test", "test")]
        [InlineData("test", "test")]
        [InlineData("TwoWords", "two_words")]
        [InlineData("TooManyManyWordsInSingleString", "too_many_many_words_in_single_string")]
        [InlineData("ItShouldWorkWithNumbers123", "it_should_work_with_numbers123")]
        public void ToSnakeCase_ShouldConvertStringToSnakeCaseNotation(string value, string expected)
        {
            // Act
            var actual = value.ToSnakeCase();

            // Assert
            actual.Should().Be(expected);
        }
    }
}
