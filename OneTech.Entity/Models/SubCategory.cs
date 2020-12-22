using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductSubCategory> ProductCategories { get; set; }
    }
}
