using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IFeaturedProductService : IGenericeService<FeaturedProduct>
    { 
        List<FeaturedProduct> GetAll (); 
        List<FeaturedProduct> GetAllProducts ();
    }
}
