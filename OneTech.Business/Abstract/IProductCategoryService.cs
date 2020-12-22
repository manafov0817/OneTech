using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductCategoryService
    {
        ProductCategory GetById ( int id );
        List<ProductCategory> GetAll ();
        void Create ( ProductCategory entity );
        void Update ( ProductCategory entity );
        void Delete ( ProductCategory entity );
    }
}
