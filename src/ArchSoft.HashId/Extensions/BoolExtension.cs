namespace ArchSoft.HashId.Extensions;

public static class BoolExtension
{
    public static string NormalizeForHashing(this bool value)
        => value.ToString().ToLowerInvariant();
}
