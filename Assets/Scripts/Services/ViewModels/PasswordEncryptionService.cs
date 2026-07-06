using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Chiffre un mot de passe
    /// </summary>
    public static class PasswordEncryptionService
    {
        /// <summary>
        /// This constant is used to determine the keysize of the encryption algorithm in bits.
        /// We divide this by 8 within the code below to get the equivalent number of bytes.
        /// </summary>
        private const int Keysize = 256;

        /// <summary>
        /// This constant determines the number of iterations for the password bytes generation function.
        /// </summary>
        private const int DerivationIterations = 1000;

        /// <summary>
        /// Chiffre la chaîne de caractères renseignée
        /// </summary>
        /// <param name="target">Texte à chiffrer</param>
        /// <param name="key">Clé de chiffrement</param>
        /// <returns>Le texte chiffré</returns>
        public static string Encrypt(string target, string key)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(target);

            using Rfc2898DeriveBytes password = new(key, saltStringBytes, DerivationIterations);
            byte[] keyBytes = password.GetBytes(Keysize / 8);

            using RijndaelManaged symmetricKey = new();
            symmetricKey.BlockSize = 256;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;

            using ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes);
            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
            byte[] cipherTextBytes = saltStringBytes;
            cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
            cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Déchiffre la chaîne de caractères renseignée
        /// </summary>
        /// <param name="cipherText">Texte à déchiffrer</param>
        /// <param name="key">Clé de déchiffrement</param>
        /// <returns>Le texte déchiffré</returns>
        public static string Decrypt(string cipherText, string key)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using Rfc2898DeriveBytes password = new(key, saltStringBytes, DerivationIterations);
            byte[] keyBytes = password.GetBytes(Keysize / 8);

            using RijndaelManaged symmetricKey = new();
            symmetricKey.BlockSize = 256;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;

            using ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes);
            using MemoryStream memoryStream = new(cipherTextBytes);
            using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream, Encoding.UTF8);
            return streamReader.ReadToEnd();
        }

        /// <summary>
        /// Génère des données de chiffrement aléatoires
        /// </summary>
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            byte[] randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (RNGCryptoServiceProvider rngCsp = new())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }

            return randomBytes;
        }
    }
}