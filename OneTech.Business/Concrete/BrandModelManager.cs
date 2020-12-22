using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class BrandModelManager : IBrandModelService
    {
        private IBrandModelRepository _brandModelRepository;
        public BrandModelManager ( IBrandModelRepository brandModelRepository )
        {
            _brandModelRepository = brandModelRepository;
        }
        public void Create ( BrandModel entity )
        {
            _brandModelRepository.Create(entity);
        }

        public void Delete ( BrandModel entity )
        {
            _brandModelRepository.Delete(entity);
        }

        public List<BrandModel> GetAll ()
        {
            return _brandModelRepository.GetAll( );
        }

        public List<BrandModel> GetBrandModelsWithBrands ()
        {
            return _brandModelRepository.GetBrandModelsWithBrands( );
        }

        public BrandModel GetById ( int id )
        {
            return _brandModelRepository.GetById(id);
        }

        public List<BrandModel> GetModelsByBrandId ( int id )
        {
            return _brandModelRepository.GetModelsByBrandId(id);
        }

        public void Update ( BrandModel entity )
        {
            _brandModelRepository.Update(entity);
        }
    }
}
