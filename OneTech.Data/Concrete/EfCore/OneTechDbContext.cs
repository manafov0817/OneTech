using Microsoft.EntityFrameworkCore;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class OneTechDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }    
        public DbSet<ProductMainCategory> ProductMainCategories { get; set; }


        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog = OneTechDbContext; Integrated Security = SSPI");
        }

        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<ProductOptionValue>( ).HasKey(c => new { c.ProductId, c.OptionValueId });


            modelBuilder.Entity<ProductPhoto>( ).HasKey(c => new { c.ProductId, c.PhotoId });


            modelBuilder.Entity<ProductReview>( ).HasKey(c => new { c.ProductId, c.ReviewId });


            modelBuilder.Entity<ProductSubCategory>( ).HasKey(c => new { c.ProductId, c.SubCategoryId });


            modelBuilder.Entity<ProductCategory>( ).HasKey(c => new { c.ProductId, c.CategoryId });


            modelBuilder.Entity<ProductMainCategory>( ).HasKey(c => new { c.ProductId, c.MainCategoryId });

       }
    }
}
