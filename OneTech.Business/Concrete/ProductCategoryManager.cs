using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryManager ( IProductCategoryRepository productCategoryRepository )
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public void Create ( ProductCategory entity )
        {
            _productCategoryRepository.Create(entity);
        }

        public void Delete ( ProductCategory entity )
        {
            _productCategoryRepository.Delete(entity);
        }

        public List<ProductCategory> GetAll ()
        {
            return _productCategoryRepository.GetAll( );
        }

        public ProductCategory GetById ( int id )
        {
            return _productCategoryRepository.GetById(id);
        }

        public void Update ( ProductCategory entity )
        {
            _productCategoryRepository.Update(entity);
        }
    }
}
