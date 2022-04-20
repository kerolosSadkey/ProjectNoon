using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Phone : Base
    {
        [MaxLength(11)]
        [RegularExpression("([0-9]+)")]
        public string PhoneNumber { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
