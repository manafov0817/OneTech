using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager ( ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;
        }
        public void Create ( Category entity )
        {
            _categoryRepository.Create(entity);
        }

        public void Delete ( Category entity )
        {
            _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll ()
        {
            return _categoryRepository.GetAll( );
        }

        public List<Category> GetAllCategoriesWithMainCategory ()
        {
            return _categoryRepository.GetAllCategoriesWithMainCategory( );
        }

        public List<Category> GetAllWithEverything ()
        {
            return _categoryRepository.GetAllWithEverything( );
        }

        public Category GetById ( int id )
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> GetCategoriesByMainCategoryId ( int id )
        {
            return _categoryRepository.GetCategoriesByMainCategoryId(id);
        }

        public Category GetCategoryWithMainCategoryById ( int id )
        {
            return _categoryRepository.GetCategoryWithMainCategoryById(id);
        }

        public void Update ( Category entity )
        {
            _categoryRepository.Update(entity);
        }
    }
}
