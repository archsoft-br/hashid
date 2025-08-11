using System.Globalization;

namespace ArchSoft.HashId.UnitTest
{
    public class HashIdTests
    {
        [Theory]
        [InlineData("abc", "BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD")]
        [InlineData("", "E3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B855")]
        [InlineData("  ABC ", "BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD")] // Normalização externa não aplicada
        public void Generate_WithSingleStringInput_ShouldReturnExpectedHash(string input, string expectedHash)
        {
            var result = HashId.GenerateNormalized(input);
            Assert.Equal(expectedHash, result);
        }

        [Fact]
        public void Generate_WithMultipleFields_ShouldReturnExpectedHash()
        {
            // Arrange
            var date = new DateTime(2025, 8, 2, 10, 0, 0);
            
            var expectedHash = "94CF5AF7B17AE983AF354956F8849518FD8D8EDFFB8D1CC1B18CDD20A77E3AE8";

            // Act
            var result = HashId.GenerateNormalized(
                " João ",
                123.45m,
                456.78,
                789.01f,
                true,
                date,
                DayOfWeek.Friday
            );

            // Assert
            Assert.Equal(expectedHash, result);
        }
        
        [Fact]
        public void Generate_ShouldProduceSameHash_ForLogicallyEquivalentObjects()
        {
            // Arrange
            var list = new List<object[]>
            {
                new object[] { " João ", 123.45m, true },
                new object[] { "joão", 123.45000m, true },
                new object[] { "JOÃO", 123.450000000m, true },
                new object[] { " joao", 123.45m, true }
            };

            var hashes = list
                .Select(fields => HashId.GenerateNormalized(fields))
                .ToList();

            // Act
            var distinctHashes = hashes.Distinct().ToList();

            // Assert
            Assert.Single(distinctHashes);
        }
    }
}