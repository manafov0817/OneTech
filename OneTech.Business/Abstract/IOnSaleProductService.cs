using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IOnSaleProductService : IGenericeService<OnSaleProduct>
    { 
        List<OnSaleProduct> GetAll (); 
        List<OnSaleProduct> GetAllProducts ();
    }
}
