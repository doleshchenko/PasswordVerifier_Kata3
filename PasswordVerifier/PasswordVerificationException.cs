using System;

namespace PasswordVerifier
{
    public class PasswordVerificationException : Exception
    {
        internal PasswordVerificationException(string message) : base(message)
        {
        }
    }
}