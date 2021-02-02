using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreProductRelateRepository : EfCoreGenericRepository<ProductRelate, OneTechDbContext>, IProductRelateRepository
    {
        public List<ProductRelate> GetAllByGivenRelateId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.ProductRelates
                              .Where(pr => pr.RelateId == id)
                              .ToList( );
            }
        }
    }
}
