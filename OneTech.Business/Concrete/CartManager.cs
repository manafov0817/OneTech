using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public partial class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager ( ICartRepository cartRepository )
        {
            _cartRepository = cartRepository;
        }

        public void Create ( Cart entity )
        {
            _cartRepository.Create(entity);
        }

        public void Delete ( Cart entity )
        {
            _cartRepository.Delete(entity);
        }

        public List<Cart> GetAll ()
        {
            return _cartRepository.GetAll( );
        }

        public Cart GetById ( int id )
        {
            return _cartRepository.GetById(id);
        }


    }
    public partial class CartManager : ICartService
    {
        public Cart GetByUserId ( string id )
        {
            return _cartRepository.GetByUserId(id);

        }

        public void InitializeCart ( string userId )
        {
            _cartRepository.Create(new Cart( ) { UserId = userId });
        }

        public void Update ( Cart entity )
        {
            _cartRepository.Update(entity);
        }
    }
}
