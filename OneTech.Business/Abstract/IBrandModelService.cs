using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IBrandModelService : IGenericeService<BrandModel>
    {      
        List<BrandModel> GetAll ();     
        List<BrandModel> GetBrandModelsWithBrands ();
        List<BrandModel> GetModelsByBrandId ( int id );
    }
}
