using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer : Base
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(200)]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        // Each customer has one cart
        public ICollection<Cart> Cart { get; set; }

        // Each customer has a collection of Phones
        public ICollection<Phone> Phones { get; set; }

        // Each customer has collection of addresses
        public ICollection<Address> Address { get; set; }

        // Each cusotmer has a collection of Reviews
        public ICollection<Reviews> Reviews { get; set; }

        // Each customer has a collection of Cards
        public ICollection<Card> Cards { get; set; }

        // Each Customer has a collection of Wishlist
        public ICollection<Wishlist> Wishlists { get; set; }

        // Each Customer has a collection of Likes
        public ICollection<Likes> Likes { get; set; }

        // Each Customer has a collection of OrderSummaries
        public ICollection<OrderSummary> orderSummaries { get; set; }

    }
}

