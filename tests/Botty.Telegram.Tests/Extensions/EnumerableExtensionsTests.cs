using Botty.Telegram.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Botty.Telegram.Tests.Extensions
{
    public class EnumerableExtensionsTests
    {
        public static IEnumerable<object[]> EmptyCases 
            => new List<object[]>
            {
                new object[] { null },
                new object[] { new List<int>() }
            };
        public static IEnumerable<object[]> NotEmptyCases
            => new List<object[]>
            {
                new object[] { new List<int> { 1, 2 ,3 } }
            };

        [Theory]
        [MemberData(nameof(EmptyCases))]
        public void IsEmpty_ShouldReturnTrue(IEnumerable<int> enumerable)
        {
            // Act
            var actual = enumerable.IsEmpty();

            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(NotEmptyCases))]
        public void IsEmpty_ShouldReturnFalse(IEnumerable<int> enumerable)
        {
            // Act
            var actual = enumerable.IsEmpty();

            // Assert
            actual.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(NotEmptyCases))]
        public void IsNotEmpty_ShouldReturnTrue(IEnumerable<int> enumerable)
        {
            // Act
            var actual = enumerable.IsNotEmpty();

            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(EmptyCases))]
        public void IsNotEmpty_ShouldReturnFalse(IEnumerable<int> enumerable)
        {
            // Act
            var actual = enumerable.IsNotEmpty();

            // Assert
            actual.Should().BeFalse();
        }
    }
}
