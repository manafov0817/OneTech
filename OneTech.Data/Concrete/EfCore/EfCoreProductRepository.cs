using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, OneTechDbContext>, IProductRepository
    {
        public List<Product> GetAllDiscountedProducts ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Where(p => p.DiscountWithMoney > 0 || p.DiscountWithPercent > 0)
                        .Include(p => p.ProductPhotos)
                            .ThenInclude(pp => pp.Photo)
                        .ToList( );
            }
        }

        public List<Product> GetAllProductsForShop ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Include(p => p.ProductPhotos)
                            .ThenInclude(pp => pp.Photo)
                        .ToList( );
            }
        }

        public Product GetProductForDetailById ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Where(p => p.Id == id)
                        .Include(p => p.ProductPhotos)
                            .ThenInclude(pp => pp.Photo)
                        .Include(p => p.ProductSubCategories)
                            .ThenInclude(ps => ps.SubCategory)
                                .ThenInclude(s => s.Category)
                                    .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductCategories)
                            .ThenInclude(pc => pc.Category)
                                .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductMainCategories)
                            .ThenInclude(pmc => pmc.MainCategory)
                        .Include(p => p.ProductOptionValues)
                            .ThenInclude(pov => pov.OptionValue)
                                .ThenInclude(ov => ov.Option)
                        .Include(p => p.ProductRelate)
                                .ThenInclude(pr => pr.Relate)
                        .FirstOrDefault( );
            }
        }

        public List<Product> GetProductsByBrandId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                                .Include(p => p.BrandModel)
                                    .ThenInclude(bm => bm.Brand)
                                .Include(p => p.ProductPhotos)
                                    .ThenInclude(pp => pp.Photo)
                                .Include(p => p.ProductCategories)
                                .Include(p => p.ProductMainCategories)
                                .Include(p => p.ProductSubCategories)
                                .Where(p => p.BrandModel.BrandId == id)
                                .ToList( );
            }
        }

        public List<Product> GetProductsByCategoryId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<ProductCategory> productCategories = context.ProductCategories
                                                                 .Where(pc => pc.CategoryId == id)
                                                                 .ToList( );
                List<Product> products = new List<Product>( );
                foreach (ProductCategory productCategory in productCategories)
                {
                    Product product = context.Products
                                             .Where(p => p.Id == productCategory.ProductId)
                                             .Include(p => p.ProductPhotos)
                                                 .ThenInclude(pp => pp.Photo)
                                             .FirstOrDefault( );
                    products.Add(product);
                }

                List<SubCategory> subCategories = context.SubCategories.Where(sc => sc.CategoryId == id)
                                                                       .Include(sc => sc.ProductSubCategories)
                                                                       .ToList( );

                if (subCategories != null && subCategories.Count( ) > 0)
                {
                    foreach (SubCategory subCategory in subCategories)
                    {
                        foreach (ProductSubCategory productSubCategory in subCategory.ProductSubCategories)
                        {
                            Product product = context.Products
                                                    .Where(p => p.Id == productSubCategory.ProductId)
                                                    .Include(p => p.ProductPhotos)
                                                        .ThenInclude(pp => pp.Photo)
                                                    .FirstOrDefault( );
                            if (!products.Contains(product))
                            {
                                products.Add(product);
                            }
                        }
                    }
                }

                return products;
            }
        }

        public List<Product> GetProductsByMainCategoryId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<ProductMainCategory> productMainCategories = context.ProductMainCategories
                                                                 .Where(pc => pc.MainCategoryId == id)
                                                                 .ToList( );
                List<Product> products = new List<Product>( );
                foreach (ProductMainCategory productMainCategory in productMainCategories)
                {
                    Product product = context.Products
                                             .Where(p => p.Id == productMainCategory.ProductId)
                                             .Include(p => p.ProductPhotos)
                                                 .ThenInclude(pp => pp.Photo)
                                             .FirstOrDefault( );
                    products.Add(product);
                }

                List<Category> categories = context.Categories.Where(c => c.MainCategoryId == id)
                                                              .Include(c => c.ProductCategories)
                                                              .ToList( );

                if (categories != null && categories.Count( ) > 0)
                {
                    foreach (Category category in categories)
                    {
                        foreach (ProductCategory productCategory in category.ProductCategories)
                        {
                            Product product = context.Products
                                                    .Where(p => p.Id == productCategory.ProductId)
                                                    .Include(p => p.ProductPhotos)
                                                        .ThenInclude(pp => pp.Photo)
                                                    .FirstOrDefault( );
                            if (!products.Contains(product))
                            {
                                products.Add(product);
                            }
                        }
                    }
                }


                List<SubCategory> subCategories = context.SubCategories.Include(sc => sc.Category)
                                                                       .Where(sc => sc.Category.MainCategoryId == id)
                                                                       .Include(sc => sc.ProductSubCategories)
                                                                       .ToList( );

                if (subCategories != null && subCategories.Count( ) > 0)
                {
                    foreach (SubCategory subCategory in subCategories)
                    {
                        foreach (ProductSubCategory productSubCategory in subCategory.ProductSubCategories)
                        {
                            Product product = context.Products
                                                    .Where(p => p.Id == productSubCategory.ProductId)
                                                    .Include(p => p.ProductPhotos)
                                                        .ThenInclude(pp => pp.Photo)
                                                    .FirstOrDefault( );
                            if (!products.Contains(product))
                            {
                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }
        }

        public List<Product> GetProductsByName ( string name )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<Product> products = context.Products
                                                    .Where(p=>p.Name.ToLower().Contains(name.ToLower()))
                                                    .Include(p => p.ProductPhotos)
                                                        .ThenInclude(pp => pp.Photo)
                                                    .Include(p => p.ProductCategories)
                                                    .Include(p => p.ProductMainCategories)
                                                    .Include(p => p.ProductSubCategories)
                                                    .ToList( );
                return products;
            }
        }

        public List<Product> GetProductsByOptionValueId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<ProductOptionValue> productOptionValues = context.ProductOptionValues
                                                                                 .ToList( );
                List<Product> products = new List<Product>( );

                List<Product> contextProducts = context.Products
                                                            .Include(p => p.ProductPhotos)
                                                                .ThenInclude(pp => pp.Photo)
                                                            .Include(p => p.ProductCategories)
                                                            .Include(p => p.ProductMainCategories)
                                                            .Include(p => p.ProductSubCategories)
                                                            .ToList( );

                foreach (ProductOptionValue productOptionValue in productOptionValues)
                {
                    if (productOptionValue.OptionValueId == id)
                    {
                        Product product = context.Products
                                                .Where(p => p.Id == productOptionValue.ProductId)
                                                .Include(p => p.ProductPhotos)
                                                    .ThenInclude(pp => pp.Photo)
                                                .Include(p => p.ProductCategories)
                                                .Include(p => p.ProductMainCategories)
                                                .Include(p => p.ProductSubCategories)
                                                .FirstOrDefault( );
                        if (!products.Contains(product))
                        {
                            products.Add(product);
                        }
                    }
                }
                return products;
            }
        }

        public List<Product> GetProductsBySubCategoryId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<ProductSubCategory> productSubCategories = context.ProductSubCategories
                                                                 .Where(pc => pc.SubCategoryId == id)
                                                                 .ToList( );
                List<Product> products = new List<Product>( );
                foreach (ProductSubCategory productSubCategory in productSubCategories)
                {
                    Product product = context.Products
                                             .Where(p => p.Id == productSubCategory.ProductId)
                                             .Include(p => p.ProductPhotos)
                                                 .ThenInclude(pp => pp.Photo)
                                             .FirstOrDefault( );
                    products.Add(product);
                }

                return products;
            }
        }

        public List<Product> GetProductWithCategoryTypes ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Include(p => p.ProductPhotos)
                            .ThenInclude(pp => pp.Photo)
                        .Include(p => p.ProductSubCategories)
                            .ThenInclude(ps => ps.SubCategory)
                                .ThenInclude(s => s.Category)
                                    .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductCategories)
                            .ThenInclude(pc => pc.Category)
                                .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductMainCategories)
                            .ThenInclude(pmc => pmc.MainCategory)
                        .ToList( );
            }
        }

        public Product GetProductWithEverythingById ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Where(p => p.Id == id)
                        .Include(p => p.ProductPhotos)
                            .ThenInclude(pp => pp.Photo)
                        .Include(p => p.ProductSubCategories)
                            .ThenInclude(ps => ps.SubCategory)
                                .ThenInclude(s => s.Category)
                                    .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductCategories)
                            .ThenInclude(pc => pc.Category)
                                .ThenInclude(c => c.MainCategory)
                        .Include(p => p.ProductMainCategories)
                            .ThenInclude(pmc => pmc.MainCategory)
                        .Include(p => p.ProductOptionValues)
                            .ThenInclude(pov => pov.OptionValue)
                                .ThenInclude(ov => ov.Option)
                        .FirstOrDefault( );
            }
        }

        public List<Product> GetTopProducts ()
        {
            throw new NotImplementedException( );
        }

        public Product GetWithRelateById ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Products
                        .Include(p => p.ProductRelate)
                            .ThenInclude(pr => pr.Relate)
                        .FirstOrDefault( );
            }
        }
    }
}
