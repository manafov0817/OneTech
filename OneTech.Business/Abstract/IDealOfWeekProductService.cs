﻿using OneTech.Entity.ComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
    public interface IDealOfWeekProductService : IGenericeService<DealOfWeekProduct>
    { 
        List<DealOfWeekProduct> GetAll (); 
        List<DealOfWeekProduct> GetAllProducts ();
    }
}
