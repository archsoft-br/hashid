using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.Normalizers;

public static class HashNormalizer
{
    public static string Normalize(object field)
    {
        if (field == null)
            return string.Empty;

        return field switch
        {
            string s => s.NormalizeForHashing(),
            decimal d => d.NormalizeForHashing(),
            double dbl => dbl.NormalizeForHashing(),
            float f => f.NormalizeForHashing(),
            bool b => b.NormalizeForHashing(), 
            DateTime dt => dt.NormalizeForHashing(),
            Enum e => e.NormalizeForHashing(),
            _ => field.ToString()?.NormalizeForHashing() ?? string.Empty
        };
    }
}