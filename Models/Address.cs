﻿using System;
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
        [Range(10000, 99999)]
        public int PostalCode { get; set; }

        // Each address is belonged to one customer
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        // Each address is belonged to one supplier
        [ForeignKey("Seller")]
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        // Each address is belonged to one shipper
        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public Shipper Shipper { get; set; }
    }
}
