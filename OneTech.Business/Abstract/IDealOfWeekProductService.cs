using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IDealOfWeekProductService
    {
        DealOfWeekProduct GetById ( int id );
        List<DealOfWeekProduct> GetAll ();
        void Create ( DealOfWeekProduct entity );
        void Update ( DealOfWeekProduct entity );
        void Delete ( DealOfWeekProduct entity );
        List<DealOfWeekProduct> GetAllProducts ();
    }
}
