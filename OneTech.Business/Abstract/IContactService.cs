using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IContactService
    {
        Contact GetById ( int id );
        List<Contact> GetAll ();
        void Create ( Contact entity );
        void Update ( Contact entity );
        void Delete ( Contact entity );
    }
}
