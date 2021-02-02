using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class PopularCategoryManager : IPopularCategoryService
    {
        private readonly IPopularCategoryRepository _popularCategoryRepository;
        public PopularCategoryManager ( IPopularCategoryRepository popularCategoryRepository )
        {
            _popularCategoryRepository = popularCategoryRepository;
        }
        public void Create ( PopularCategory entity )
        {
            _popularCategoryRepository.Create(entity);
        }

        public void Delete ( PopularCategory entity )
        {
            _popularCategoryRepository.Delete(entity);
        }

        public List<PopularCategory> GetAll ()
        {
            return _popularCategoryRepository.GetAll( );
        }

        public PopularCategory GetById ( int id )
        {
            return _popularCategoryRepository.GetById(id);
        }

        public void Update ( PopularCategory entity )
        {
            _popularCategoryRepository.Update(entity);
        }
    }
}
