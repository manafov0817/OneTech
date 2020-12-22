using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductMainCategory> ProductMainCategories { get; set; }
    }
}
