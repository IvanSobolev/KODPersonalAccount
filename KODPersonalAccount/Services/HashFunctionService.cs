using System.Security.Cryptography;
using System.Text;

namespace KODPersonalAccount.Services;

public static class HashFunctionService
{
    public static Task<string> ComputeHmacSha256Async(string key, string data)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Task.FromResult(BitConverter.ToString(hashBytes).Replace("-", "").ToLower());
    }
}