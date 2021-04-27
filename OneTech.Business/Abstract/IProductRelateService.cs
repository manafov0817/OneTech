using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
   public interface IProductRelateService : IGenericeService<ProductRelate>
    {  
        List<ProductRelate> GetAll (); 
        List<ProductRelate> GetAllByGivenRelateId ( int id );
    }
}
