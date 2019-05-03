using System;

namespace waUser.Extensions
{ 
    internal class StringLengthAttribute : Attribute
    {
        private readonly int v;
        private readonly string ErrorMessage;
        private readonly int MinimumLength;

        public StringLengthAttribute(int v, string ErrorMessage, int MinimumLength)
        {
            this.v = v;
            this.ErrorMessage = ErrorMessage;
            this.MinimumLength = MinimumLength;
        }
    }
}