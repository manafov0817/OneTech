using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreOptionRepository : EfCoreGenericRepository<Option, OneTechDbContext>, IOptionRepository
    {
        public Option GetByName ( string value )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Options
                                   .Where(o => o.Name.ToLower( ) == value.ToLower( ))
                                   .FirstOrDefault( );
            }
        }
    }
}
