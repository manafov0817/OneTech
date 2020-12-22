using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IBrandService
    {
        Brand GetById ( int id );
        List<Brand> GetAll ();
        void Create ( Brand entity );
        void Update ( Brand entity );
        void Delete ( Brand entity );
    }
}
