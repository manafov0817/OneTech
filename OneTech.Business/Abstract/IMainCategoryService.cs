using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IMainCategoryService
    {
        MainCategory GetById ( int id );
        List<MainCategory> GetAll ();
        void Create ( MainCategory entity );
        void Update ( MainCategory entity );
        void Delete ( MainCategory entity );
        List<MainCategory> GetAllWithEverything ();
    }
}
