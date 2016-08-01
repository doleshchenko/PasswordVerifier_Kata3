using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PasswordVerifier
{
    public class PasswordVerifier
    {
        public bool Verify(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (password.Length < 8)
            {
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                return false;
            }
            if (!password.Any(char.IsLower))
            {
                return false;
            }
            if (!password.Any(char.IsNumber))
            {
                return false;
            }

            return true;
        }
    }
}
