using System.Globalization;
using ArchSoft.HashId.Constants;

namespace ArchSoft.HashId.Extensions;

public static class DoubleExtension
{
    public static string NormalizeForHashing(this Double value)
    {
        return value.ToString(FormatConstant.Number, CultureInfo.InvariantCulture);
    }
}