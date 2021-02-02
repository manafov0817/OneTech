using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IProductRelateRepository:IRepository<ProductRelate>
    {
        List<ProductRelate> GetAllByGivenRelateId ( int id );
    }
}
