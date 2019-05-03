using System;

namespace waUser.Extensions
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}
