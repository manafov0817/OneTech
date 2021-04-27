using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IBestRatedProductService : IGenericeService<BestRatedProduct>
    {
        List<BestRatedProduct> GetAll ();     
        List<BestRatedProduct> GetAllProducts ();
    }
}
