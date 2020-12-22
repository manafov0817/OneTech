using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager ( ICartRepository cartRepository )
        {
            _cartRepository = cartRepository;
        }

        public void Create ( Cart entity )
        {
            throw new NotImplementedException( );
        }

        public void Delete ( Cart entity )
        {
            throw new NotImplementedException( );
        }

        public List<Cart> GetAll ()
        {
            throw new NotImplementedException( );
        }

        public Cart GetById ( int id )
        {
            throw new NotImplementedException( );
        }

        public void InitializeCart ( string userId )
        {
            _cartRepository.Create(new Cart( ) { UserId = userId });
        }

        public void Update ( Cart entity )
        {
            throw new NotImplementedException( );
        }
    }
}
