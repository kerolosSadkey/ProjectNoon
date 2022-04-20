using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cart : Base
    {
        // Each cart is belonged to one customer
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        // Each cart contains collection of products
        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public Product Products { get; set;}

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
