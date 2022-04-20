using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orders : Base
    {

        // Each Order is made by one Customer
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        // Each Order is shipped by one Shipper

        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public User Shipper { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsPaid { get; set; }

        public decimal Discount { get; set; }

        public string DeliveryStatus { get; set; }

        // Each Order has a collection of OrderDetails
        public ICollection<OrderItems> OrderItems { get; set; }

        public Orders()
        {
            OrderDate = DateTime.Now;
        }
    }
}
