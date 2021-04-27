using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WepApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string DiscountStart { get; set; }
        public string DiscountEnd { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
