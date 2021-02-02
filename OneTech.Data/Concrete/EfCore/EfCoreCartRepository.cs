using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, OneTechDbContext>, ICartRepository
    {
        public Cart GetByUserId ( string id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.Carts.Where(c => c.UserId == id).FirstOrDefault();
            }
        }
    }
}
