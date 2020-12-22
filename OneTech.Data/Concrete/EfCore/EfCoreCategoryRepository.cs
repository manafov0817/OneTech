using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, OneTechDbContext>, ICategoryRepository
    {
        public List<Category> GetAllCategoriesWithMainCategory ()
        {
            using (var context = new OneTechDbContext( ))
            {
                List<Category> categories = context.Categories.Include(c => c.MainCategory).ToList( );
                return categories;
            }
        }

        public List<Category> GetAllWithEverything ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Categories
                                .Include(c => c.MainCategory)
                                .Include(c=>c.SubCategories)
                                .ToList( );
            }
        }

        public List<Category> GetCategoriesByMainCategoryId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                List<Category> categories = context.Categories.Where(c => c.MainCategoryId == id).ToList( );
                return categories;
            }
        }

        public Category GetCategoryWithMainCategoryById ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Categories
                                    .Where(c => c.Id == id)
                                    .Include(c => c.MainCategory)
                                    .FirstOrDefault( );
            }
        }
    }
}
