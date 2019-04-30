using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace waUser.Models
{
    public class User
    {
        public long UserID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Confirmed { get; set; }

        public DateTime CreationDate { get; set; }
 
    }

    internal class Customer : User
    {
        internal string Name { get; set; }

        internal string SurName { get; set; }
    }
}
