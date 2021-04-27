using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IMainCategoryService : IGenericeService<MainCategory>
    { 
        List<MainCategory> GetAll (); 
        List<MainCategory> GetAllWithEverything ();
    }
}
