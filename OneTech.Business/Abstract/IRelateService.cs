using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IRelateService : IGenericeService<Relate>
    { 
        List<Relate> GetAll (); 
    }
}
