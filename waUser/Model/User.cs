using System;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = waUser.Extensions.RequiredAttribute;
using StringLengthAttribute = waUser.Extensions.StringLengthAttribute;

namespace waUser.Models
{
    public class User
    {
        public long UserID { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [StringLength(80, ErrorMessage: "Must be between 5 and 80 characters", MinimumLength: 5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(80, ErrorMessage: "Must be between 8 and 80 characters", MinimumLength: 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string IMEI { get; set; }

        public bool Confirmed { get; set; }

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? CreationDate { get; set; }
 
    }

    internal class Customer : User
    {
        internal string Name { get; set; }

        internal string SurName { get; set; }
    }
}
