using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreBrandModelRepository : EfCoreGenericRepository<BrandModel, OneTechDbContext>, IBrandModelRepository
    {
        public List<BrandModel> GetBrandModelsWithBrands ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.BrandModels.Include(b => b.Brand).ToList( );
            }
        }

        public List<BrandModel> GetModelsByBrandId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.BrandModels.Where(bm=>bm.BrandId==id).ToList( );
            }
        }
    }
}
