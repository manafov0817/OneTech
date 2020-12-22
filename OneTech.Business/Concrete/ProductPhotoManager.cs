using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ProductPhotoManager : IProductPhotoService
    {
        private IProductPhotoRepository _productPhotoRepository;
        public ProductPhotoManager ( IProductPhotoRepository productPhotoRepository )
        {
            _productPhotoRepository = productPhotoRepository;
        }
        public void Create ( ProductPhoto entity )
        {
            _productPhotoRepository.Create(entity);
        }

        public void Delete ( ProductPhoto entity )
        {
            _productPhotoRepository.Delete(entity);
        }

        public List<ProductPhoto> GetAll ()
        {
            return _productPhotoRepository.GetAll( );
        }

        public ProductPhoto GetById ( int id )
        {
            return _productPhotoRepository.GetById(id);
        }

        public void Update ( ProductPhoto entity )
        {
            _productPhotoRepository.Update(entity);
        }
    }
}
