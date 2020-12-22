using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface ICartService
    {
        Cart GetById ( int id );
        List<Cart> GetAll ();
        void Create ( Cart entity );
        void Update ( Cart entity );
        void Delete ( Cart entity );
    }
}
