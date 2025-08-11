using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class DoubleExtensionTests
    {
        [Theory]
        [InlineData(0.0, "0")]
        [InlineData(1.2345, "1.2345")]
        [InlineData(123456.78901234, "123456.78901234")]
        [InlineData(-98765.4321, "-98765.4321")]
        [InlineData(0.00000000000123, "0.00000000000123")]
        [InlineData(123.00000000000000, "123")]
        [InlineData(1.23000000000000, "1.23")]
        public void NormalizeForHashing_ShouldFormatCorrectlyWithInvariantCulture(double input, string expected)
        {
            // Act
            var result = input.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldUseDotAsDecimalSeparator()
        {
            // Arrange
            double value = 1234.56;

            // Act
            var result = value.NormalizeForHashing();

            // Assert
            Assert.DoesNotContain(",", result);
            Assert.Contains(".", result);
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void NormalizeForHashing_SpecialValues_ShouldReturnExpectedStrings(double input)
        {
            // Act
            var result = input.NormalizeForHashing();

            // Assert
            Assert.Equal(input.ToString("0.################", CultureInfo.InvariantCulture), result);
        }
    }
}