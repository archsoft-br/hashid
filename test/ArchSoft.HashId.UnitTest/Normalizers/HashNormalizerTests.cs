using System.Globalization;
using ArchSoft.HashId.Normalizers;

namespace ArchSoft.HashId.UnitTest.Normalizers
{
    public class HashNormalizerTests
    {
        [Fact]
        public void Normalize_NullInput_ReturnsEmptyString()
        {
            var result = HashNormalizer.Normalize(null);
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData(" João ", "joao")]
        [InlineData("Olá    Mundo", "ola mundo")]
        [InlineData("  TÊxto   Com   AÇENTOS  ", "texto com acentos")]
        [InlineData("CAfé   COM  LEITE", "cafe com leite")]
        [InlineData("   Espaços    e    AÇENTOS   ", "espacos e acentos")]
        public void Normalize_String_ReturnsNormalizedString(string input, string expected)
        {
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.0, "0")]
        [InlineData(1.2345, "1.2345")]
        [InlineData(123456.78901234, "123456.78901234")]
        [InlineData(-98765.4321, "-98765.4321")]
        [InlineData(0.00000000000123, "0.00000000000123")]
        [InlineData(123.00000000000000, "123")]
        [InlineData(1.23000000000000, "1.23")]
        public void Normalize_Double_ReturnsFormattedInvariant(double input, string expected)
        {
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.0f, "0")]
        [InlineData(1.2345f, "1.2345")]
        [InlineData(123456.789f, "123456.789")]
        [InlineData(-98765.4321f, "-98765.43")]
        [InlineData(0.000000000123f, "0.000000000123")]
        [InlineData(123.0000000f, "123")]
        [InlineData(1.2300000f, "1.23")]
        public void Normalize_Float_ReturnsFormattedInvariant(float input, string expected)
        {
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.0, "0")]
        [InlineData(123.456, "123.456")]
        [InlineData(-9876.54321, "-9876.54321")]
        [InlineData(0.000000123456789, "0.000000123456789")]
        [InlineData(123.00000000000000, "123")]
        [InlineData(1.23000000000000, "1.23")]
        public void Normalize_Decimal_ReturnsFormattedInvariant(double value, string expected)
        {
            decimal input = (decimal)value;
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        public void Normalize_Bool_ReturnsLowercaseString(bool input, string expected)
        {
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(DayOfWeek.Monday, "monday")]
        [InlineData(DayOfWeek.Sunday, "sunday")]
        [InlineData(DayOfWeek.Wednesday, "wednesday")]
        public void Normalize_Enum_ReturnsLowercaseName(DayOfWeek input, string expected)
        {
            var result = HashNormalizer.Normalize(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Normalize_DateTime_ReturnsUtcFormatted()
        {
            // Arrange
            var dt = new DateTime(2025, 08, 02, 15, 30, 45, DateTimeKind.Local);
            var expected = dt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            // Act
            var result = HashNormalizer.Normalize(dt);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Normalize_OtherObject_UsesToStringAndThenNormalizes()
        {
            // Arrange
            var obj = new CustomType { Value = "TÊxto   PErsonalizado " };
            var expected = "texto personalizado";

            // Act
            var result = HashNormalizer.Normalize(obj);

            // Assert
            Assert.Equal(expected, result);
        }

        private class CustomType
        {
            public string Value { get; set; }
            public override string ToString() => Value;
        }
    }
}
