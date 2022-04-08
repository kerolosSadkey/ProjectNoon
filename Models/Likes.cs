using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Likes : Base
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
