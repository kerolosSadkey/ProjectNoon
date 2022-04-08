using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Images : Base
    {
        public byte[] Image { get; set; }

        // Each Image is belonged to one Product
        public ICollection<Product> Product { get; set; }

        // Each Image is belonged to one Category
        public ICollection<Category> Category { get; set; }
    }
}
