using System;
using System.Security.Cryptography;
using System.Text;

namespace Chorap4e.Common
{
    public static class HashUtils
    {
        public static string HashPassword(string plainPassword)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(plainPassword);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
    {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
