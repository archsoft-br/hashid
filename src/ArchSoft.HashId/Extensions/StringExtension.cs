using ArchSoft.HashId.Utils;

namespace ArchSoft.HashId.Extensions;

public static class StringExtension
{
    public static string RemoveDiacritics(this string text)
        => StringUtil.RemoveDiacritics(text);

    public static string RemoveMultipleSpaces(this string text)
        => StringUtil.RemoveMultipleSpaces(text);

    public static string NormalizeForHashing(this string text)
    {
        return text
            .RemoveDiacritics()
            .RemoveMultipleSpaces()
            .ToLowerInvariant()
            .Trim();
    }
}
