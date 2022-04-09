using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order : Base
    {

        // Each OrderDetails is related to one order
        public OrderSummary OrderSummary { get; set; }

        // Each Order is considered as buying a one Product
        [ForeignKey("product")]
        public int ProductID { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
