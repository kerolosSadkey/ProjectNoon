using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reviews : Base
    {
        // Each Review is given by one customer
        [Required]
        public Customer Customer { get; set; }

        // Each Review is given for one specific Product
        [Required]
        public Product Product { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
