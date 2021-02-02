using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IRelateService
    {
        Relate GetById ( int id );
        List<Relate> GetAll ();
        void Create ( Relate entity );
        void Update ( Relate entity );
        void Delete ( Relate entity );
    }
}
