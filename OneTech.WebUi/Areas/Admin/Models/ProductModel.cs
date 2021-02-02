using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Models
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int BrandModelId { get; set; }
        public int RelateProductId { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<int> SubCategoryIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> MainCategoryIds { get; set; }
        [Required]
        public List<int> OptionValueIds { get; set; }
        [Required]
        public int ColorId { get; set; }
    }
    public class ProductEditModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int BrandModelId { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<int> SubCategoryIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> MainCategoryIds { get; set; }
        [Required]
        public List<int> OptionValueIds { get; set; }
        [Required]
        public int ColorId { get; set; }
    }
    public class ProductDetailModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int BrandModelId { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<int> SubCategoryIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> MainCategoryIds { get; set; }
        [Required]
        public List<int> OptionValueIds { get; set; }
        [Required]
        public int ColorId { get; set; }
    }
    public class ProductForDiscount
    {
        public int ProductId { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? DiscountWithMoney { get; set; }
        public decimal? DiscountWithPercent { get; set; }
        public int DiscountType { get; set; }
        public DateTime DiscountStarts { get; set; }
        public DateTime DiscountEnds { get; set; }
    }
}
