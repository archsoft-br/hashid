namespace ArchSoft.HashId.Extensions;

public static class EnumExtension
{
    public static string NormalizeForHashing(this Enum value)
        => value.ToString().ToLowerInvariant();
}
