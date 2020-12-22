using OneTech.Data.Concrete.EfCore;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IProductCategoryRepository : IRepository<ProductCategory> { }
}
