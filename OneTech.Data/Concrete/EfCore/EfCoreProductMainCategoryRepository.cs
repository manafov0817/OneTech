using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreProductMainCategoryRepository : EfCoreGenericRepository<ProductMainCategory, OneTechDbContext>, IProductMainCategoryRepository { }
}
