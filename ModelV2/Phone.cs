using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Phone : Base
    {
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public Shipper Shipper { get; set; }
    }
}
