using System;

namespace Common
{
    public class HashUtils
    {
        public static long GetLongHashCode(string stringInput)
        {
            byte[] byteContents = Encoding.Unicode.GetBytes(stringInput);
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
            byte[] hashText = hash.ComputeHash(byteContents);
            return BitConverter.ToInt64(hashText, 0) ^ BitConverter.ToInt64(hashText, 7);
        }

        public static int GetIntHashCode(string stringInput)
        {
            return (int)GetLongHashCode(stringInput);
        }

        public static string CreateHashCode(string stringInput)
        {
            // STEP 1 Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // STEP 2 Create the Rfc2898DeriveBytes and get the hash value:
            // Note: Depending on the performance requirements of your specific application, the value '10000' can be reduced. A minimum value should be around 1000.
            var pbkdf2 = new Rfc2898DeriveBytes(stringInput, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // STEP 3 Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // STEP 4 Turn the combined salt+hash into a string for storage
            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        public static bool VerifyPassword(string plainPassword, string storedHash)
        {
            /* Fetch the stored value & Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            /* Get the salt */
            byte[] salt = new byte[16];

            //ServiceEventSource.Current.Debug(String.Format("Plain password length : {0}, hashed password length: {1}, hashed bytes length: {2}",
            //    plainPassword.Length, storedHash.Length, hashBytes == null ? "null" : hashBytes.Length.ToString()));

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

        public static string Sha1(string input)
        {
            var hashInBytes = new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join(string.Empty, Array.ConvertAll(hashInBytes, b => b.ToString("x2")));
        }

        public static string GetRandomString(int length)
        {
            var random = new Random();
            string[] chars = new string[] { "0", "2", "3", "4", "5", "6", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            return sb.ToString();
        }

        public static string CreateReferralCode()
        {
            Guid g = Guid.NewGuid();
            string guidString = Convert.ToBase64String(g.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            guidString = guidString.Replace("/", "");
            return guidString;
        }

        public static int ConvertCustomIdToInt(CustomId id)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(id.ToString()));
            int ivalue = BitConverter.ToInt32(hashed, 0);
            return Math.Abs(ivalue);
        }

        public static int ConvertCustomIdToInt(string id)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(id));
            int ivalue = BitConverter.ToInt32(hashed, 0);
            return Math.Abs(ivalue);
        }
    }
}
