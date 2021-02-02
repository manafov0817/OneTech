using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class FeaturedProductManager : IFeaturedProductService
    {
        private readonly IFeaturedProductRepository _featuredProductRepository;
        public FeaturedProductManager ( IFeaturedProductRepository featuredProductRepository )
        {
            _featuredProductRepository = featuredProductRepository;
        }
        public void Create ( FeaturedProduct entity )
        {
            _featuredProductRepository.Create(entity);
        }

        public void Delete ( FeaturedProduct entity )
        {
            _featuredProductRepository.Delete(entity);
        }

        public List<FeaturedProduct> GetAll ()
        {
            return _featuredProductRepository.GetAll( );
        }

        public List<FeaturedProduct> GetAllProducts ()
        {
            return _featuredProductRepository.GetAllProducts( );
        }

        public FeaturedProduct GetById ( int id )
        {
            return _featuredProductRepository.GetById(id);
        }

        public void Update ( FeaturedProduct entity )
        {
            _featuredProductRepository.Update(entity);
        }
    }
}
