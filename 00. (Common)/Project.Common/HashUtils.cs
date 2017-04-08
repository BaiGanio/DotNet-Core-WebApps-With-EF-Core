using System;
using System.Security.Cryptography;

namespace Project.Common
{
    public class HashUtils
    {
        public static string CreateHashCode(string stringInput)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Note: Depending on the performance requirements of your specific application,
            // the value '10000' can be reduced. A minimum value should be around 1000.
            var pbkdf2 = new Rfc2898DeriveBytes(stringInput, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string passwordHash = Convert.ToBase64String(hashBytes);
            return passwordHash;
        }

        /* Verify the plain password againts the stored hash for a user */
        public static bool VerifyPassword(string plainPassword, string storedHash)
        {
            /* Fetch the stored value & Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
