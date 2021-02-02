using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Entity.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? DiscountWithPercent { get; set; }
        public decimal? DiscountWithMoney { get; set; }
        public string DiscountStart { get; set; }
        public string DiscountEnd { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public bool Status { get; set; }
        public ProductRelate ProductRelate { get; set; }
        public DateTime AddedDate { get; set; }
        public int BrandModelId { get; set; }
        public BrandModel BrandModel { get; set; }
        public List<ProductSubCategory> ProductSubCategories { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductMainCategory> ProductMainCategories { get; set; }
        public List<ProductPhoto> ProductPhotos { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
        public List<ProductOptionValue> ProductOptionValues { get; set; }
    }
}
