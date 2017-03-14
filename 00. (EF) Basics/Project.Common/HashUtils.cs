using System;
using System.Security.Cryptography;

namespace Project.Common
{
    public class HashUtils
    {
        /* Create Hash Password so we can secure the user */
        public static string CreateHashCode(string stringInput)
        {
            /* STEP 1 - Create the salt value with a cryptographic PRNG: */
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            /* STEP 2 - Create the Rfc2898DeriveBytes and get the hash value: */
            // Note: Depending on the performance requirements of your specific application, the value '10000' can be reduced. A minimum value should be around 1000.
            var pbkdf2 = new Rfc2898DeriveBytes(stringInput, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* STEP 3 - Combine the salt and password bytes for later use: */
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            /* STEP 4 - Turn the combined salt+hash into a string for storage */
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
