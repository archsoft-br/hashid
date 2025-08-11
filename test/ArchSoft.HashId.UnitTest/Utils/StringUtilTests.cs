using ArchSoft.HashId.Utils;

namespace ArchSoft.HashId.UnitTest.Utils
{
    public class StringUtilTests
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData("   ", "")]
        [InlineData("abc", "abc")]
        [InlineData("  abc", " abc")]
        [InlineData("abc  ", "abc ")]
        [InlineData("abc   def", "abc def")]
        [InlineData("  abc   def  ghi  ", " abc def ghi ")]
        [InlineData("a   b   c", "a b c")]
        public void RemoveMultipleSpaces_ShouldNormalizeInternalSpaces(string input, string expected)
        {
            var result = StringUtil.RemoveMultipleSpaces(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData("   ", "")]
        [InlineData("café", "cafe")]
        [InlineData("ação", "acao")]
        [InlineData("TÊXTÔ CÕM ÀCÊNTOS", "TEXTO COM ACENTOS")]
        [InlineData("João", "Joao")]
        [InlineData("façade naïve soupçon", "facade naive soupcon")]
        public void RemoveDiacritics_ShouldRemoveAccents(string input, string expected)
        {
            var result = StringUtil.RemoveDiacritics(input);
            Assert.Equal(expected, result);
        }
    }
}