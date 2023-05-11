using System.Security.Cryptography;
using System.Text;

namespace Oyster.Utils;

public static class Crypto
{
    public static string GeneratePwdHash(string plainPwd)
    {
        using var sha256Hash = SHA256.Create();
        // ComputeHash - returns byte array  
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainPwd));  
  
        // Convert byte array to a string   
        var builder = new StringBuilder();  
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }  
        return builder.ToString();
    }
}