using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.HashGenerator
{
    internal class Program
    {
        static void Main()
        {
            string password = "Sophia123*";

            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (Rfc2898DeriveBytes pbkdf2 =
                new Rfc2898DeriveBytes(password, salt, 100000))
            {
                hash = pbkdf2.GetBytes(64);
            }

            Console.WriteLine("SALT:");
            Console.WriteLine(BitConverter.ToString(salt).Replace("-", ""));

            Console.WriteLine("\nHASH:");
            Console.WriteLine(BitConverter.ToString(hash).Replace("-", ""));
        }
    }
}
