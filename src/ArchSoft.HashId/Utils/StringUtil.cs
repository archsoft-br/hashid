using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchSoft.HashId.Utils;

public static partial class StringUtil
{
    [GeneratedRegex(@"\s+", RegexOptions.None, matchTimeoutMilliseconds: 1000)]
    private static partial Regex MultipleSpacesRegex();

    public static string RemoveMultipleSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        
        return MultipleSpacesRegex().Replace(text, " ");
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
