using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
   public interface IGenericeService<T>
    {
        T GetById ( int id );
        void Create ( T entity );
        void Update ( T entity );
        void Delete ( T entity );
    }
}
