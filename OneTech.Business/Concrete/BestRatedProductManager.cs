using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class BestRatedProductManager : IBestRatedProductService
    {
        private readonly IBestRatedProductRepository _bestRatedProductRepository;
        public BestRatedProductManager ( IBestRatedProductRepository bestRatedProductRepository )
        {
            _bestRatedProductRepository = bestRatedProductRepository;
        }
        public void Create ( BestRatedProduct entity )
        {
            _bestRatedProductRepository.Create(entity);
        }

        public void Delete ( BestRatedProduct entity )
        {
            _bestRatedProductRepository.Delete(entity);
        }

        public List<BestRatedProduct> GetAll ()
        {
            return _bestRatedProductRepository.GetAll( );
        }

        public List<BestRatedProduct> GetAllProducts ()
        {
            return _bestRatedProductRepository.GetAllProducts( );
        }

        public BestRatedProduct GetById ( int id )
        {
            return _bestRatedProductRepository.GetById(id);
        }

        public void Update ( BestRatedProduct entity )
        {
            _bestRatedProductRepository.Update(entity);
        }
    }
}
