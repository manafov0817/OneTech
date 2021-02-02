using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreBestRatedProductRepository : EfCoreGenericRepository<BestRatedProduct, OneTechDbContext>, IBestRatedProductRepository
    {
        public List<BestRatedProduct> GetAllProducts ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.BestRatedProducts.Include(dofw => dofw.Product)
                                                 .ThenInclude(p => p.ProductPhotos)
                                                    .ThenInclude(pp => pp.Photo)
                                                 .ToList( );
            }
        }
    }
}
