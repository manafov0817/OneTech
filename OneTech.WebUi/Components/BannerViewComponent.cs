using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class BannerViewComponent : ViewComponent
    {

        private readonly IBannerService _bannerService;
        public BannerViewComponent ( IBannerService bannerService )
        {
            _bannerService = bannerService;
        }
        public IViewComponentResult Invoke ()
        {

            return View(_bannerService.GetBanner());
        }
    }
}
