using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address : Base
    {
        [Required, MinLength(3)]
        public string Street { get; set; }

        [Required, MinLength(3)]
        public string City { get; set; }

        // Egyptian postal code consists of 5 digits
        public int PostalCode { get; set; }

        // Each address is belonged to one User
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }


    }
}
