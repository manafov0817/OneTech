using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class FeaturedModel
    {
        public List<FeaturedProduct> FeaturedProducts { get; set; }
        public List<DealOfWeekProduct> DealOfWeekProducts { get; set; }
        public List<BestRatedProduct> BestRatedProducts { get; set; }
        public List<OnSaleProduct> OnSaleProducts { get; set; }
    }
    public class FeaturedAddModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string FeatureType { get; set; }
    }
}
