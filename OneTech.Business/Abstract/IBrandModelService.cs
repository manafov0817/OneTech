using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IBrandModelService
    {
        BrandModel GetById ( int id );
        List<BrandModel> GetAll ();
        void Create ( BrandModel entity );
        void Update ( BrandModel entity );
        void Delete ( BrandModel entity );
        List<BrandModel> GetBrandModelsWithBrands ();
        List<BrandModel> GetModelsByBrandId ( int id );
    }
}
