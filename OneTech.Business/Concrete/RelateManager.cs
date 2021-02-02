using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class RelateManager : IRelateService
    {
        private IRelateRepository _relateRepository;
        public RelateManager ( IRelateRepository relateRepository )
        {
            _relateRepository = relateRepository;
        }
        public void Create ( Relate entity )
        {
            _relateRepository.Create( entity);
        }

        public void Delete ( Relate entity )
        {
            _relateRepository.Delete(entity);
        }

        public List<Relate> GetAll ()
        {
           return _relateRepository.GetAll( );
        }


        public Relate GetById ( int id )
        {
            return _relateRepository.GetById(id);
        }

        public void Update ( Relate entity )
        {
            _relateRepository.Update(entity);
        }
    }
}
