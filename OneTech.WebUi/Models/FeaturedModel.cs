using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Models
{
    public class FeaturedModel
    {
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> DealOfWeekProducts { get; set; }
        public List<Product> BestRatedProducts { get; set; }
        public List<Product> OnSaleProducts { get; set; }
    }
}
