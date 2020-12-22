using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductOptionValueService
    {
        ProductOptionValue GetById ( int id );
        List<ProductOptionValue> GetAll ();
        void Create ( ProductOptionValue entity );
        void Update ( ProductOptionValue entity );
        void Delete ( ProductOptionValue entity );

    }
}
