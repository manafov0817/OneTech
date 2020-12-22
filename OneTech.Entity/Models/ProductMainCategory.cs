using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class ProductMainCategory
    {
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
