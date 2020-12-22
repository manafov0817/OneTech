using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class MainCategoryManager : IMainCategoryService
    {
        private IMainCategoryRepository _mainCategoryRepository;
        public MainCategoryManager ( IMainCategoryRepository mainCategoryRepository )
        {
            _mainCategoryRepository = mainCategoryRepository;
        }
        public void Create ( MainCategory entity )
        {
            _mainCategoryRepository.Create(entity);
        }

        public void Delete ( MainCategory entity )
        {
            _mainCategoryRepository.Delete(entity);
        }

        public List<MainCategory> GetAll ()
        {
            return _mainCategoryRepository.GetAll( );
        }

        public List<MainCategory> GetAllWithEverything ()
        {
            return _mainCategoryRepository.GetAllWithEverything( );
        }

        public MainCategory GetById ( int id )
        {
            return _mainCategoryRepository.GetById(id);
        }

        public void Update ( MainCategory entity )
        {
            _mainCategoryRepository.Update(entity);
        }
    }
}
