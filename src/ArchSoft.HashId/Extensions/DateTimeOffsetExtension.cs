using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class DateTimeOffsetExtension
{
    public static string NormalizeForHashing(this DateTimeOffset value)
        => value.UtcDateTime.ToString(FormatConstant.DateTime, CultureInfo.InvariantCulture);
}
