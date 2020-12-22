using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface ISubCategoryRepository : IRepository<SubCategory> 
    {
        List<SubCategory> GetAllSubCategoriesWithCategoryAndMainCategory ();
        List<SubCategory> GetSubCategoriesByCategoryId ( int id);
        SubCategory GetSubCategoryWithCategoryAndMainCategorybyId ( int id);
    }
}
