using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface ISubCategoryService
    {
        SubCategory GetById ( int id );
        List<SubCategory> GetAll ();
        void Create ( SubCategory entity );
        void Update ( SubCategory entity );
        void Delete ( SubCategory entity );
        List<SubCategory> GetAllSubCategoriesWithCategoryAndMainCategory ();
        List<SubCategory> GetSubCategoriesByCategoryId ( int id );
        SubCategory GetSubCategoryWithCategoryAndMainCategorybyId ( int id );
    }
}
