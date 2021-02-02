using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
   public interface IProductRelateService
    {
        ProductRelate GetById ( int id );
        List<ProductRelate> GetAll ();
        void Create ( ProductRelate entity );
        void Update ( ProductRelate entity );
        void Delete ( ProductRelate entity );
        List<ProductRelate> GetAllByGivenRelateId ( int id );
    }
}
