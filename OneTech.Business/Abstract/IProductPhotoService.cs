using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IProductPhotoService
    {
        ProductPhoto GetById ( int id );
        List<ProductPhoto> GetAll ();
        void Create ( ProductPhoto entity );
        void Update ( ProductPhoto entity );
        void Delete ( ProductPhoto entity );
    }
}
