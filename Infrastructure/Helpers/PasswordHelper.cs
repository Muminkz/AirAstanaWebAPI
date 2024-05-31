using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
