using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class DateTimeExtension
{
    public static string NormalizeForHashing(this DateTime value)
    {
        if (value.Kind == DateTimeKind.Unspecified)
            value = DateTime.SpecifyKind(value, DateTimeKind.Utc);

        return value.ToUniversalTime().ToString(FormatConstant.DateTime, CultureInfo.InvariantCulture);
    }
}
