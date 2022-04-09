using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Phone : Base
    {
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Seller")]
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public Shipper Shipper { get; set; }
    }
}
