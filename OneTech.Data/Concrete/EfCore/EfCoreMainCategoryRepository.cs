using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreMainCategoryRepository : EfCoreGenericRepository<MainCategory, OneTechDbContext>, IMainCategoryRepository
    {
        public List<MainCategory> GetAllWithEverything ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.MainCategories
                              .Include(mc => mc.Categories)
                                .ThenInclude(c => c.SubCategories)
                                .ToList( );                                   
            }
        }
    }
}
