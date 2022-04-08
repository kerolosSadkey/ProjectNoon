using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Shipper : Base
    {
        [Required, MaxLength(50)]
        public string ShipperName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(200)]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        // Each Shipper has a collection of Phones
        public ICollection<Phone> Phones { get; set; }

        // Each Shipper has a collection of Address
        public ICollection<Address> Address { get; set; }

        // Each Shipper has a collection of Cards
        public ICollection<Card> Cards { get; set; }
    }
}
