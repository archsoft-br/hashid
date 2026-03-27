using System.Security.Cryptography;
using System.Text;
using ArchSoft.HashId.Constants;
using ArchSoft.HashId.Normalizers;

namespace ArchSoft.HashId;

public static class HashId
{
    public static string GenerateNormalized(string content)
    {
        content = HashNormalizer.Normalize(content);
        return Create(content);
    }
    
    public static string GenerateNormalized(params object[] fields)
    {
        var normalizedFields = fields.Select(field => HashNormalizer.Normalize(field));
        var content = string.Join(FormatConstant.Separator, normalizedFields);

        return Create(content);
    }
    
    public static string GenerateUnnormalized(string content)
    {
        return Create(content ?? string.Empty);
    }
    
    public static string GenerateUnnormalized(params object[] fields)
    {
        var content = string.Join(FormatConstant.Separator, fields);

        return Create(content);
    }
    
    private static string Create(string content)
    {
        var byteCount = Encoding.UTF8.GetByteCount(content);
        Span<byte> bytes = byteCount <= 256
            ? stackalloc byte[byteCount]
            : new byte[byteCount];
        Encoding.UTF8.GetBytes(content, bytes);

        Span<byte> hash = stackalloc byte[SHA256.HashSizeInBytes];
        SHA256.HashData(bytes, hash);

        return Convert.ToHexString(hash);
    }
}
