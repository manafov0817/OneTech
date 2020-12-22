using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById ( int id );
        List<Category> GetAll ();
        void Create ( Category entity );
        void Update ( Category entity );
        void Delete ( Category entity );
        List<Category> GetAllCategoriesWithMainCategory ();
        List<Category> GetCategoriesByMainCategoryId ( int id );
        Category GetCategoryWithMainCategoryById ( int id );
        List<Category> GetAllWithEverything ();
    }
}
