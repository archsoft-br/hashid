using ArchSoft.HashId.Utils;

namespace ArchSoft.HashId.Extensions;

public static class StringExtension
{
    public static string RemoveDiacritics(this string text)
    {
        return StringUtil.RemoveDiacritics(text);
    }

    public static string RemoveMultipleSpaces(this string text)
    {
        return StringUtil.RemoveMultipleSpaces(text);
    }

    public static string NormalizeForHashing(this string text)
    {
        return text
            .RemoveDiacritics()
            .RemoveMultipleSpaces()
            .ToLowerInvariant()
            .Trim();
    }
}