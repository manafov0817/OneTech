using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreDealOfWeekProductRepository : EfCoreGenericRepository<DealOfWeekProduct, OneTechDbContext>, IDealOfWeekProductRepository
    {
        public List<DealOfWeekProduct> GetAllProducts ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.DealOfWeekProducts.Include(dofw => dofw.Product)
                                                 .ThenInclude(p => p.ProductPhotos)
                                                    .ThenInclude(pp => pp.Photo)
                                                 .ToList( );
            }
        }
    }
}
