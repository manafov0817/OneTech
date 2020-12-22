using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCorePhotoRepository : EfCoreGenericRepository<Photo, OneTechDbContext>, IPhotoRepository { }
}
