using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class BannerManager : IBannerService
    {
        private IBannerRepository _bannerRepository;
        public BannerManager ( IBannerRepository bannerRepository )
        {
            _bannerRepository = bannerRepository;
        }
        public void Create ( Banner entity )
        {
            _bannerRepository.Create(entity);
        }

        public void Delete ( Banner entity )
        {
            _bannerRepository.Delete(entity);
        }

        public List<Banner> GetAll ()
        {
           return _bannerRepository.GetAll( );
        }

        public Banner GetBanner ()
        {
            return _bannerRepository.GetBanner( );
        }

        public Banner GetById ( int id )
        {
            return _bannerRepository.GetById(id);
        }

        public void Update ( Banner entity )
        {
            _bannerRepository.Update(entity);
        }
    }
}
