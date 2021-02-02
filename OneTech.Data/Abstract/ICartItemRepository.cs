using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        List<CartItem> GetByCartId ( int id );
        List<CartItem> GetByUserId ( string id );
    }
}
