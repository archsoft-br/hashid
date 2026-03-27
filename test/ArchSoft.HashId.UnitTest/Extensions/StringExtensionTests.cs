using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("áéíóú", "aeiou")]
        [InlineData("çãõ", "cao")]
        [InlineData("Êxâmplê", "Example")]
        [InlineData("João", "Joao")]
        [InlineData("Crème Brûlée", "Creme Brulee")]
        [InlineData("ÁÉÍÓÚàèìòù", "AEIOUaeiou")]
        public void RemoveDiacritics_ShouldRemoveAllAccents(string input, string expected)
        {
            var result = input.RemoveDiacritics();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hello  World", "Hello World")]
        [InlineData("One   Two  Three ", "One Two Three ")]
        [InlineData("Multiple     spaces", "Multiple spaces")]
        [InlineData("NoExtraSpaces", "NoExtraSpaces")]
        [InlineData("A    B     C  ", "A B C ")]
        public void RemoveMultipleSpaces_ShouldCollapseInternalSpaces(string input, string expected)
        {
            var result = input.RemoveMultipleSpaces();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("João ", "joao")]
        [InlineData("Olá    Mundo", "ola mundo")]
        [InlineData(" TÊxto   Com   AÇENTOS  ", "texto com acentos")]
        [InlineData("CAfé   COM  LEITE", "cafe com leite")]
        [InlineData("Espaços    e    AÇENTOS   ", "espacos e acentos")]
        public void NormalizeForHashing_ShouldTrimLowerRemoveDiacriticsAndMultipleSpaces(string input, string expected)
        {
            var result = input.NormalizeForHashing();

            Assert.Equal(expected, result);
        }
    }
}

    
