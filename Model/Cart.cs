using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cart : Base
    {
        // Each cart is belonged to one customer
        public Customer Customer { get; set; }

        // Each cart contains collection of products
        public Product Products { get; set;}

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
