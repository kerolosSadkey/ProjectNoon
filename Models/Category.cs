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
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string NameArabic { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string DescriptionArabic { get; set; }

        // Each Category has an Image
        [ForeignKey("Image")]
        public int ImageId { get; set; }
        public Images Image { get; set; }

        // If Category has a Parent_ID -Which is a self relation to Category ID- it means it's subcategory
        [ForeignKey("Parent")]
        public int ParentID { get; set; }
        public Category Parent { get; set; }

        // Each Category has a collection of products
        public ICollection<Product> products { get; set; }
    }
}
