using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCorePopularCategoryRepository : EfCoreGenericRepository<PopularCategory, OneTechDbContext>, IPopularCategoryRepository    {    }
}
