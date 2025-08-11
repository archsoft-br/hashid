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
        var content = string.Join("|", normalizedFields);

        return Create(content);
    }
    
    public static string GenerateUnnormalized(string content)
    {
        return Create(content);
    }
    
    public static string GenerateUnnormalized(params object[] fields)
    {
        var content = string.Join(FormatConstant.Separator, fields);

        return Create(content);
    }
    
    private static string Create(string content)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            var hash = sha256.ComputeHash(bytes);
            var hexadecimal = Convert.ToHexString(hash);

            return hexadecimal;
        }
    }
}