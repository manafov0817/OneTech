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
    public class EfCoreBannerRepository : EfCoreGenericRepository<Banner, OneTechDbContext>, IBannerRepository
    {
        public Banner GetBanner ()
        {
            using (var context = new OneTechDbContext( ))
            {

                return context.Banner
                              .Include(b=>b.Product)
                                  .ThenInclude(p=>p.ProductPhotos)
                                       .ThenInclude(pp=>pp.Photo)
                              .FirstOrDefault( );
            }
        }
    }
}
