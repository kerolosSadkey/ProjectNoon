using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category : Base
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Each Category has an Image
        [Required]
        public Images Image { get; set; }

        // If Category has a Parent_ID -Which is a self relation to Category ID- it means it's subcategory
        public int ParentID { get; set; }

        [ForeignKey("ParentID")]
        public Category Parent { get; set; }

        // Each Category has a collection of products
        public ICollection<Product> products { get; set; }
    }
}
