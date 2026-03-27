using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class DoubleExtension
{
    public static string NormalizeForHashing(this double value)
        => value.ToString(FormatConstant.Number, CultureInfo.InvariantCulture);
}
