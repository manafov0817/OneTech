using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
