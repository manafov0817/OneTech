using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface ICartService : IGenericeService<Cart>
    {
        List<Cart> GetAll ();
        Cart GetByUserId ( string id );
        void InitializeCart ( string id );
    }
}
