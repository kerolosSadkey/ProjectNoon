using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderSummary : Base
    {

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }

        // Each Order is made by one Customer
        public Customer Customer { get; set; }

        // Each Order is shipped by one Shipper
        public Shipper Shipper { get; set; }

        public string OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsPaid { get; set; }

        public decimal Discount { get; set; }

        public string DeliveryStatus { get; set; }

        // Each Order has a collection of OrderDetails
        public ICollection<Order> orders { get; set; }
    }
}
