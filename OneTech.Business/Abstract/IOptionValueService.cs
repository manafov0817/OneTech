using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IOptionValueService
    {
        OptionValue GetById ( int id );
        List<OptionValue> GetAll ();
        void Create ( OptionValue entity );
        void Update ( OptionValue entity );
        void Delete ( OptionValue entity );
        List<OptionValue> GetAllWithOptions ();
        List<OptionValue> GetAllColors ();
        List<OptionValue> GetOptionValuesByOptionId ( int id );
    }
}
