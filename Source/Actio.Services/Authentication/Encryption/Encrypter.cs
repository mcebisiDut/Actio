using System;
using System.Security.Cryptography;
using Authentication.IEncryption;

namespace Authentication.Encryption
{
    public class Encrypter : IEncrypter
    {
        private static readonly int SaltSize = 40;
        private static readonly int DeriveBytesIterationCount = 10000;
        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value,GetBytes(salt),DeriveBytesIterationCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GetSalt(string value)
        {
            var random = new Random();
            var saltBytes = new Byte[SaltSize];
            var randoNumberGenerator = RandomNumberGenerator.Create();
            randoNumberGenerator.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length*sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(),0,bytes,0,bytes.Length);

            return bytes;
        }
    }
}