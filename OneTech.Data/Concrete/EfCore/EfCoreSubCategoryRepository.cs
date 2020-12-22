using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreSubCategoryRepository : EfCoreGenericRepository<SubCategory, OneTechDbContext>, ISubCategoryRepository
    {
        public List<SubCategory> GetAllSubCategoriesWithCategoryAndMainCategory ()
        {
            using (var context = new OneTechDbContext( ))
            {
                List<SubCategory> subCategories = context.SubCategories
                                                         .Include(sc => sc.Category)
                                                         .ThenInclude(c => c.MainCategory)
                                                         .ToList( );
                return subCategories;
            }
        }

        public List<SubCategory> GetSubCategoriesByCategoryId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<SubCategory> subCategories = context.SubCategories.Where(sc => sc.CategoryId == id).ToList( );

                return subCategories;
            }
        }

     
        public SubCategory GetSubCategoryWithCategoryAndMainCategorybyId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                SubCategory subCategory = context.SubCategories
                                                         .Where(sc => sc.SubCategoryId == id)
                                                         .Include(sc => sc.Category)
                                                         .ThenInclude(c => c.MainCategory)
                                                         .FirstOrDefault( );
                return subCategory;
            }
        }
    }
}
