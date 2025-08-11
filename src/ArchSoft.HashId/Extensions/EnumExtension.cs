namespace ArchSoft.HashId.Extensions;

public static class EnumExtension
{
    public static string NormalizeForHashing(this Enum value)
    {
        return value.ToString().ToLowerInvariant();
    }  
}