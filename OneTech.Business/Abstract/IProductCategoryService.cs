using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductCategoryService : IGenericeService<ProductCategory>
    { 
        List<ProductCategory> GetAll (); 
    }
}
