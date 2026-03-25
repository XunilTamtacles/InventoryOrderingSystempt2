using System.Security.Cryptography;
using System.Text;

namespace InventoryOrderingSystem.Helpers
{
    public class SecurityHelper
    {
        
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[8]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        
        public static string HashPassword(string password, string salt)
        {
            string combined = password + salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

    
        public static bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)
        {
            string hashOfInput = HashPassword(inputPassword, storedSalt);

            return hashOfInput == storedHash;
        }

        internal static string HashPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}