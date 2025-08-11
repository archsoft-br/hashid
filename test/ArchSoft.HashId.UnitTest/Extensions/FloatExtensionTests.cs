using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class FloatExtensionTests
    {
        [Theory]
        [InlineData(0.0f, "0")]
        [InlineData(1.2345f, "1.2345")]
        [InlineData(-98765.4321f, "-98765.43")] 
        [InlineData(0.000000000123f, "0.000000000123")]
        [InlineData(123.0000000f, "123")]
        [InlineData(1.2300000f, "1.23")]
        public void NormalizeForHashing_ShouldFormatCorrectlyWithInvariantCulture(float input, string expected)
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
            float value = 1234.56f;

            // Act
            var result = value.NormalizeForHashing();

            // Assert
            Assert.DoesNotContain(",", result);
            Assert.Contains(".", result);
        }

        [Theory]
        [InlineData(float.NaN)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity)]
        public void NormalizeForHashing_SpecialValues_ShouldReturnExpectedStrings(float input)
        {
            // Act
            var result = input.NormalizeForHashing();

            // Assert
            Assert.Equal(input.ToString("0.################", CultureInfo.InvariantCulture), result);
        }
    }
}