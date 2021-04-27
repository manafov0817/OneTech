using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface ICartItemService : IGenericeService<CartItem>
    { 
        List<CartItem> GetAll ();
        List<CartItem> GetByCartId ( int id );
        List<CartItem> GetByUserId ( string id ); 
    }
}
