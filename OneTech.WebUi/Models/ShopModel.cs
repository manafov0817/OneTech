using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Models
{
    public class ShopModel
    {
        public string CategoryId { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public int PageSize { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public List<OptionValue> Colors { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
