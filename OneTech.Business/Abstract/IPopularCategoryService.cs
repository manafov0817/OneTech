using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IPopularCategoryService : IGenericeService<PopularCategory>
    { 
        List<PopularCategory> GetAll (); 
    }
}
