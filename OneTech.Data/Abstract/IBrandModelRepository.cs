using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IBrandModelRepository : IRepository<BrandModel> {
        List<BrandModel> GetBrandModelsWithBrands ();
        List<BrandModel> GetModelsByBrandId ( int id );
    }
}
