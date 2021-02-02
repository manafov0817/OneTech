using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactManager ( IContactRepository contactRepository )
        {
            _contactRepository = contactRepository;
        }
        public void Create ( Contact entity )
        {
            _contactRepository.Create(entity);
        }

        public void Delete ( Contact entity )
        {
            _contactRepository.Delete(entity);
        }

        public List<Contact> GetAll ()
        {
            return _contactRepository.GetAll( );
        }

        public Contact GetById ( int id )
        {
            return _contactRepository.GetById(id);
        }

        public void Update ( Contact entity )
        {
            _contactRepository.Update(entity);
        }
    }
}
