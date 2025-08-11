using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class FloatExtension
{
    public static string NormalizeForHashing(this float value)
    {
        return value.ToString(FormatConstant.Number, CultureInfo.InvariantCulture);
    }
}