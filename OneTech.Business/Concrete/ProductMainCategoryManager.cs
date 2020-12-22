using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ProductMainCategoryManager : IProductMainCategoryService
    {
        private IProductMainCategoryRepository _productMainCategoryRepository;
        public ProductMainCategoryManager ( IProductMainCategoryRepository productMainCategoryRepository )
        {
            _productMainCategoryRepository = productMainCategoryRepository;
        }
        public void Create ( ProductMainCategory entity )
        {
            _productMainCategoryRepository.Create(entity);
        }

        public void Delete ( ProductMainCategory entity )
        {
            _productMainCategoryRepository.Delete(entity);
        }

        public List<ProductMainCategory> GetAll ()
        {
            return _productMainCategoryRepository.GetAll( );
        }

        public ProductMainCategory GetById ( int id )
        {
            return _productMainCategoryRepository.GetById(id);
        }

        public void Update ( ProductMainCategory entity )
        {
            _productMainCategoryRepository.Update(entity);
        }
    }
}
