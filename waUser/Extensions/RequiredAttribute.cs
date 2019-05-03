using System;
using System.Net.Mail;

namespace waUser.Extensions
{
    internal class IsValid: Attribute
    {
        private readonly string Email;
        private readonly string ErrorMessage;

        public IsValid(string Email, string ErrorMessage)
        {
            this.Email = Email;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
