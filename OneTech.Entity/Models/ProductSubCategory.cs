using System;
using System.Collections.Generic;
using System.Text;


namespace OneTech.Entity.Models
{
    public class ProductSubCategory
    {
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}