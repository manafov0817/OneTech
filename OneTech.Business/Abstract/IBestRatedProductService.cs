using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IBestRatedProductService
    {
        BestRatedProduct GetById ( int id );
        List<BestRatedProduct> GetAll ();
        void Create ( BestRatedProduct entity );
        void Update ( BestRatedProduct entity );
        void Delete ( BestRatedProduct entity );
        List<BestRatedProduct> GetAllProducts ();
    }
}
