using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IOptionValueRepository : IRepository<OptionValue>
    {
        List<OptionValue> GetAllWithOptions ();
        List<OptionValue> GetAllColors ();
        List<OptionValue> GetOptionValuesByOptionId ( int id );
    }
}
