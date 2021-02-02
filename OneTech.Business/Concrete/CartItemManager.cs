using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private ICartItemRepository _cartItemRepository;
        public CartItemManager ( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public void Create ( CartItem entity )
        {
            _cartItemRepository.Create(entity);
        }

        public void Delete ( CartItem entity )
        {
            _cartItemRepository.Delete(entity);
        }

        public List<CartItem> GetAll ()
        {
            return _cartItemRepository.GetAll( );
        }

        public CartItem GetById ( int id )
        {
            return _cartItemRepository.GetById(id);
        }

        public List<CartItem> GetByCartId ( int id )
        {
            return _cartItemRepository.GetByCartId(id);
        }

        public void Update ( CartItem entity )
        {
            _cartItemRepository.Update(entity);
        }

        public List<CartItem> GetByUserId ( string id )
        {
            return _cartItemRepository.GetByUserId(id);
        }
    }
}
