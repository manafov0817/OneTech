using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IOptionValueService : IGenericeService<OptionValue>
    { 
        List<OptionValue> GetAll (); 
        List<OptionValue> GetAllWithOptions ();
        List<OptionValue> GetAllColors ();
        List<OptionValue> GetOptionValuesByOptionId ( int id );
    }
}
