using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class BoolExtensionTests
    {
        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        public void NormalizeForHashing_ShouldReturnLowercase(bool input, string expected)
        {
            // Act
            var result = input.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}