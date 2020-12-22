using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreOptionValueRepository : EfCoreGenericRepository<OptionValue, OneTechDbContext>, IOptionValueRepository
    {
        public List<OptionValue> GetAllColors ()
        {
            using (var context = new OneTechDbContext( ))
            {

                return context.OptionValues
                                    .Include(ov => ov.Option)
                                    .Where(op => op.Option.Name.ToLower( ) == "Color".ToLower( ))
                                    .ToList( ); ;
            }
        }

        public List<OptionValue> GetAllWithOptions ()
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.OptionValues.Include(ov => ov.Option).ToList( );
            }
        }

        public List<OptionValue> GetOptionValuesByOptionId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.OptionValues.Where(ov => ov.OptionId==id).ToList( );
            }
        }
    }
}
