using System.Globalization;

namespace ArchSoft.HashId.UnitTest
{
    public class HashIdTests
    {
        [Theory]
        [InlineData("abc", "BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD")]
        [InlineData("", "E3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B855")]
        [InlineData("  ABC ", "BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD")]
        public void Generate_WithSingleStringInput_ShouldReturnExpectedHash(string input, string expectedHash)
        {
            var result = HashId.GenerateNormalized(input);
            Assert.Equal(expectedHash, result);
        }

        [Fact]
        public void Generate_WithMultipleFields_ShouldReturnExpectedHash()
        {
            var date = new DateTime(2025, 8, 2, 10, 0, 0, DateTimeKind.Utc);
            
            var expectedHash = "430C4718D1EADF53ABA38B1EBCB0016A98826AE1D13D888F897DD124DA11F682";

            var result = HashId.GenerateNormalized(
                " João ",
                123.45m,
                456.78,
                789.01f,
                true,
                date,
                DayOfWeek.Friday
            );

            Assert.Equal(expectedHash, result);
        }
        
        [Fact]
        public void Generate_ShouldProduceSameHash_ForLogicallyEquivalentObjects()
        {
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

            var distinctHashes = hashes.Distinct().ToList();

            Assert.Single(distinctHashes);
        }

        [Fact]
        public void GenerateUnnormalized_WithNullString_ShouldNotThrow()
        {
            var result = HashId.GenerateUnnormalized((string)null!);

            var expectedHash = "E3B0C44298FC1C149AFBF4C8996FB92427AE41E4649B934CA495991B7852B855";
            Assert.Equal(expectedHash, result);
        }

        [Fact]
        public void GenerateUnnormalized_WithValidString_ShouldReturnHash()
        {
            var result = HashId.GenerateUnnormalized("abc");

            Assert.Equal("BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD", result);
        }
    }
}
