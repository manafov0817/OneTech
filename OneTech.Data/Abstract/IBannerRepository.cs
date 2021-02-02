using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Data.Abstract
{
    public interface IBannerRepository : IRepository<Banner>
    {
        Banner GetBanner ();
    }
}
