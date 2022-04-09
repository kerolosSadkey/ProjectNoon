using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Card : Base
    {
        [Required, MinLength(3), MaxLength(50)]
        public string NameOnCard { get; set; }

        // All Cards are only 16 digits
        [Required, MinLength(16), MaxLength(16)]
        public string CardNumber { get; set;}

        [Required, Range(1,12)]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }


        // Each card is belonged to one customer
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        // Each card is belonged to one supplier
        [ForeignKey("Seller")]
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        // Each card is belonged to one shipper
        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public Shipper Shipper { get; set; }
    }
}
