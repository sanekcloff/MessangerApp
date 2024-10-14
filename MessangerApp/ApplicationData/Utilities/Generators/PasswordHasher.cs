using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Utilities.Generators
{
    internal static class PasswordHasher
    {
        internal static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
                byte[] hashedPassword = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashedPassword);
            }
        }
        internal static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
