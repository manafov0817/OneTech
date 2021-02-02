using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class DealOfWeekProductManager : IDealOfWeekProductService
    {
        private readonly IDealOfWeekProductRepository _dealOfWeekProductRepository;
        public DealOfWeekProductManager ( IDealOfWeekProductRepository dealOfWeekProductRepository )
        {
            _dealOfWeekProductRepository = dealOfWeekProductRepository;
        }
        public void Create ( DealOfWeekProduct entity )
        {
            _dealOfWeekProductRepository.Create(entity);
        }

        public void Delete ( DealOfWeekProduct entity )
        {
            _dealOfWeekProductRepository.Delete(entity);
        }

        public List<DealOfWeekProduct> GetAll ()
        {
            return _dealOfWeekProductRepository.GetAll( );
        }

        public List<DealOfWeekProduct> GetAllProducts ()
        {
            return _dealOfWeekProductRepository.GetAllProducts( );
        }

        public DealOfWeekProduct GetById ( int id )
        {
            return _dealOfWeekProductRepository.GetById(id);
        }

        public void Update ( DealOfWeekProduct entity )
        {
            _dealOfWeekProductRepository.Update(entity);
        }
    }
}
