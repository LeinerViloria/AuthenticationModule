
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationModule.Utilities
{
    public static class Utils{

        public static string HashTo256(string Value, string Salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] BytesMessage = Encoding.UTF8.GetBytes(Value + Salt);

                byte[] hashBytes = sha256.ComputeHash(BytesMessage);

                var sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

    }
}