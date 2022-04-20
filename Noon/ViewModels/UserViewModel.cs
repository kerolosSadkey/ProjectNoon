using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noon.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
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

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(11, ErrorMessage = "Phone number must be only 11 digits")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Phone number must be only digits")]
        public string PhoneNumber { get; set; }

        [Required, MinLength(3)]
        public string Street { get; set; }

        [Required, MinLength(3)]
        public string City { get; set; }

        // Egyptian postal code consists of 5 digits
        public int PostalCode { get; set; }
    }
}