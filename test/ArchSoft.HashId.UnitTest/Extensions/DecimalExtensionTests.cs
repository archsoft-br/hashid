using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class DecimalExtensionTests
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
            // Arrange
            var value = (decimal)input;

            // Act
            var result = value.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldUseDotAsDecimalSeparator()
        {
            // Arrange
            decimal value = 1234.56M;

            // Act
            var result = value.NormalizeForHashing();

            // Assert
            Assert.DoesNotContain(",", result);
            Assert.Contains(".", result);
        }
    }
}