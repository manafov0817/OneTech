using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IOptionRepository : IRepository<Option>
    {
        Option GetByName ( string value );
    }
}
