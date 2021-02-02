using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IPopularCategoryService
    {
        PopularCategory GetById ( int id );
        List<PopularCategory> GetAll ();
        void Create ( PopularCategory entity );
        void Update ( PopularCategory entity );
        void Delete ( PopularCategory entity );
    }
}
