using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System;

namespace student_management.Helper
{
    class Function
    {
        public static bool validateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            bool isValid = regex.IsMatch(email);

            return isValid;
        }

        public static string encrypt(string input)
        {
            string key = "YourEncryptionKey";
            byte[] encryptedBytes;

            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                rijndael.Key = keyBytes;
                rijndael.Mode = CipherMode.ECB; // Electronic Codebook (ECB) mode
                rijndael.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = rijndael.CreateEncryptor();
                encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
