using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductSubCategoryService
    {
        ProductSubCategory GetById ( int id );
        List<ProductSubCategory> GetAll ();
        void Create ( ProductSubCategory entity );
        void Update ( ProductSubCategory entity );
        void Delete ( ProductSubCategory entity );
    }
}
