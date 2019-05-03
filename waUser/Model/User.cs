using System;
using System.ComponentModel.DataAnnotations;


namespace waUser.Models
{
    public class User 
    {
        public long UserID { get; set; }

        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must have a minimum length of {1} and maximum length of {0} ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email format is not correct")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 8, ErrorMessage = "Password must have a minimum length of {1} and maximum length of {0} ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string IMEI { get; set; }

        public bool Confirmed { get; set; }

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? CreationDate { get; set; }

    }



}
