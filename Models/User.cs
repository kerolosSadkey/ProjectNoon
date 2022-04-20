using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : Base
    {
        [Required(ErrorMessage ="First Name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(200)]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        // Each user has one cart
        public ICollection<Cart> Cart { get; set; }

        // Each user has a collection of Phones
        public ICollection<Phone> Phones { get; set; }

        // Each user has collection of addresses
        public ICollection<Address> Addresses { get; set; }

        // Each user has a collection of Reviews
        public ICollection<Reviews> Reviews { get; set; }

        // Each user has a collection of Cards
        public ICollection<Card> Cards { get; set; }

        // Each user has a collection of Wishlist
        public ICollection<Wishlist> Wishlists { get; set; }

        // Each user has a collection of Likes
        public ICollection<Likes> Likes { get; set; }

        // Each user has a collection of OrderSummaries
        public ICollection<Orders> Orders { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

