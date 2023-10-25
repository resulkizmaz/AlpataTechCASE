using System.Security.Cryptography;
using System.Text;

namespace Core.Rules
{
    public static class Encryptions
    {
        public static string SHA512InBase64(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                byte[] hashedInputBytes = hash.ComputeHash(bytes);
                return Convert.ToBase64String(hashedInputBytes);
            }
        }
        public static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string SHA512Hashing(string value, string salt)
        {
            string hash = Encryptions.SHA512InBase64(value);
            hash = String.Concat(hash, salt);
            return Encryptions.SHA512InBase64(hash);
        }
    }
}
