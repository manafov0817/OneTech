using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Abstract
{
   public interface IBannerService
    {
        Banner GetById ( int id );
        List<Banner> GetAll ();
        Banner GetBanner ();
        void Create ( Banner entity );
        void Update ( Banner entity );
        void Delete ( Banner entity );
    }
}
