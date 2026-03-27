using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class DecimalExtension
{
    public static string NormalizeForHashing(this decimal value)
        => value.ToString(FormatConstant.Number, CultureInfo.InvariantCulture);
}
