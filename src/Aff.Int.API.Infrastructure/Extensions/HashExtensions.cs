using System.Security.Cryptography;
using System.Text;

namespace Aff.Int.API.Core.Extensions
{
    public static class HashExtensions
    {
        public static string Sha256(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool HasNonASCIIChars(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Encoding.UTF8.GetByteCount(input) != input.Length;
        }
    }
}
