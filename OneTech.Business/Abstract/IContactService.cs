using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IContactService : IGenericeService<Contact>
    { 
        List<Contact> GetAll (); 
    }
}
