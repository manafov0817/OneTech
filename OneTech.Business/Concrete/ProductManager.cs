using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Data.Concrete.EfCore;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager ( IProductRepository productRepository )
        {
            _productRepository = productRepository;
        }
        public void Create ( Product entity )
        {
            _productRepository.Create(entity);
        }

        public void Delete ( Product entity )
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll ()
        {
            return _productRepository.GetAll( );
        }

        public List<Product> GetAllDiscountedProducts ()
        {
            return _productRepository.GetAllDiscountedProducts( );
        }

        public List<Product> GetAllProductsForShop ()
        {
            return _productRepository.GetAllProductsForShop( );
        }

        public Product GetById ( int id )
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductForDetailById ( int id )
        {
            return _productRepository.GetProductForDetailById(id);
        }

        public List<Product> GetProductsByBrandId ( int id )
        {
            return _productRepository.GetProductsByBrandId(id);
        }

        public List<Product> GetProductsByCategoryId ( int id )
        {
            return _productRepository.GetProductsByCategoryId(id);
        }

        public List<Product> GetProductsByMainCategoryId ( int id )
        {
            return _productRepository.GetProductsByMainCategoryId(id);
        }

        public List<Product> GetProductsByName ( string name )
        {
            return _productRepository.GetProductsByName(name);
        }

        public List<Product> GetProductsByOptionValueId ( int id )
        {
            return _productRepository.GetProductsByOptionValueId(id);
        }

        public List<Product> GetProductsBySubCategoryId ( int id )
        {
            return _productRepository.GetProductsBySubCategoryId(id);
        }

        public List<Product> GetProductWithCategoryTypes ()
        {
            return _productRepository.GetProductWithCategoryTypes( );
        }

        public Product GetProductWithEverythingById ( int id )
        {
            return _productRepository.GetProductWithEverythingById(id);
        }

        public List<Product> GetTopProducts ()
        {
            return _productRepository.GetTopProducts();
        }

        public Product GetWithRelateById ( int id )
        {
            return _productRepository.GetWithRelateById(id);
        }

        public void Update ( Product entity )
        {
            _productRepository.Update(entity);
        }
    }
}
