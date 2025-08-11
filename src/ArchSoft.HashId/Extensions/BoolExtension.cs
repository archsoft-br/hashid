using System.Globalization;

namespace ArchSoft.HashId.Extensions;

public static class BoolExtension
{
    public static string NormalizeForHashing(this bool value)
    {
        return value.ToString().ToLowerInvariant();
    }  
}