using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product : Base
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Weight { get; set; }

        public float Discount { get; set; }

        // Each Product has a collection of Images
        [Required]
        public ICollection<Images> Images { get; set; }

        // Each Product is sold by a collection of Sellers
        [Required]
        public Seller Sellers { get; set; }

        // Each Product has a collection of reviews
        public ICollection<Reviews> Reviews { get; set; }

        public ICollection<Likes> Likes { get; set; } 

        public ICollection<Wishlist> Wishlists { get; set; }

        // Each Product can be in many Orders
        public ICollection<Order> Orders { get; set; }

        // Each Product is related to One Category
        [Required]
        public Category Category { get; set; }

        public ICollection<Cart> Carts { get; set; }


    }
}
