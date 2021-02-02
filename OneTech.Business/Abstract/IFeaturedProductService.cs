using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IFeaturedProductService
    {
        FeaturedProduct GetById ( int id );
        List<FeaturedProduct> GetAll ();
        void Create ( FeaturedProduct entity );
        void Update ( FeaturedProduct entity );
        void Delete ( FeaturedProduct entity );
        List<FeaturedProduct> GetAllProducts ();
    }
}
