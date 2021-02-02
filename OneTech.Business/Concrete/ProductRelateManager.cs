using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ProductRelateManager : IProductRelateService
    {
        private IProductRelateRepository _productRelateRepository;
        public ProductRelateManager ( IProductRelateRepository productRelateRepository )
        {
            _productRelateRepository = productRelateRepository;
        }
        public void Create ( ProductRelate entity )
        {
            _productRelateRepository.Create(entity);
        }

        public void Delete ( ProductRelate entity )
        {
            _productRelateRepository.Delete(entity);
        }

        public List<ProductRelate> GetAll ()
        {
            return _productRelateRepository.GetAll( );
        }

        public List<ProductRelate> GetAllByGivenRelateId ( int id )
        {
            return _productRelateRepository.GetAllByGivenRelateId(id);
        }

        public ProductRelate GetById ( int id )
        {
            return _productRelateRepository.GetById(id);
        }

        public void Update ( ProductRelate entity )
        {
            _productRelateRepository.Update(entity);
        }
    }
}
