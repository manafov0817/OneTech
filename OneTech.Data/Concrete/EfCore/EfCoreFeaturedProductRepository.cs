using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreFeaturedProductRepository : EfCoreGenericRepository<FeaturedProduct, OneTechDbContext>, IFeaturedProductRepository
    {
        public List<FeaturedProduct> GetAllProducts ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.FeaturedProducts.Include(dofw => dofw.Product)
                                                 .ThenInclude(p => p.ProductPhotos)
                                                    .ThenInclude(pp => pp.Photo)
                                                 .ToList( );
            }
        }
    }
}
