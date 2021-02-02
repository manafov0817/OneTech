using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IOnSaleProductService
    {
        OnSaleProduct GetById ( int id );
        List<OnSaleProduct> GetAll ();
        void Create ( OnSaleProduct entity );
        void Update ( OnSaleProduct entity );
        void Delete ( OnSaleProduct entity );
        List<OnSaleProduct> GetAllProducts ();
    }
}
