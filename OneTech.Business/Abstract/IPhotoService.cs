using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IPhotoService
    {
        Photo GetById ( int id );
        List<Photo> GetAll ();
        void Create ( Photo entity );
        void Update ( Photo entity );
        void Delete ( Photo entity );
    }
}
