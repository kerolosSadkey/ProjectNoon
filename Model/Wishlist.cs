using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wishlist : Base
    {
        [Required]
        public Customer Customers { get; set; }

        [Required]
        public Product Product { get; set; }

    }
}
