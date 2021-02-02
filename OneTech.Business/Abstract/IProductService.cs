using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductService
    {
        Product GetById ( int id );
        List<Product> GetAll ();
        void Create ( Product entity );
        void Update ( Product entity );
        void Delete ( Product entity );
        List<Product> GetTopProducts ();
        List<Product> GetProductWithCategoryTypes ();
        List<Product> GetAllProductsForShop ();
        List<Product> GetAllDiscountedProducts ();
        List<Product> GetProductsByMainCategoryId ( int id );
        List<Product> GetProductsByCategoryId ( int id );
        List<Product> GetProductsBySubCategoryId ( int id );
        List<Product> GetProductsByOptionValueId ( int id );
        List<Product> GetProductsByBrandId ( int id );
        List<Product> GetProductsByName ( string name );
        Product GetProductWithEverythingById ( int id );
        Product GetProductForDetailById ( int id );
        Product GetWithRelateById ( int id );
    }
}
