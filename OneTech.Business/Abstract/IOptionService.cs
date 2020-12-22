using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IOptionService
    {
        Option GetById ( int id );
        List<Option> GetAll ();
        void Create ( Option entity );
        void Update ( Option entity );
        void Delete ( Option entity );
        Option GetByName ( string value );

    }
}
