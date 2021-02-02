using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class OnSaleProductManager : IOnSaleProductService
    {
        private readonly IOnSaleProductRepository _onSaleProductRepository;
        public OnSaleProductManager ( IOnSaleProductRepository onSaleProductRepository ) => _onSaleProductRepository = onSaleProductRepository;

        public void Create ( OnSaleProduct entity ) => _onSaleProductRepository.Create(entity);

        public void Delete ( OnSaleProduct entity ) => _onSaleProductRepository.Delete(entity);

        public List<OnSaleProduct> GetAll () => _onSaleProductRepository.GetAll( );

        public List<OnSaleProduct> GetAllProducts () => _onSaleProductRepository.GetAllProducts( );

        public OnSaleProduct GetById ( int id ) => _onSaleProductRepository.GetById(id);

        public void Update ( OnSaleProduct entity ) => _onSaleProductRepository.Update(entity);
    }
}
