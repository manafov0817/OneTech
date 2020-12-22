using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductMainCategoryService
    {
        ProductMainCategory GetById ( int id );
        List<ProductMainCategory> GetAll ();
        void Create ( ProductMainCategory entity );
        void Update ( ProductMainCategory entity );
        void Delete ( ProductMainCategory entity );
    }
}
