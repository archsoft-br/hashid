using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchSoft.HashId.Utils;

public static class StringUtil
{
    public static string RemoveMultipleSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        
        var result = Regex.Replace(text, @"\s+", " ");
        
        return result;
    }

    public static string RemoveDiacritics(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        var result = text.Normalize(NormalizationForm.FormD);

        var resultBuilder = new StringBuilder();
        foreach (var c in result)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark) resultBuilder.Append(c);
        }

        result = resultBuilder.ToString().Normalize(NormalizationForm.FormC);

        return result;
    }
}