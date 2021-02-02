using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using OneTech.WebUi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IProductService _productService;

        public BannerController ( IBannerService bannerService,
                                  IProductService productService )
        {
            _bannerService = bannerService;
            _productService = productService;
        }
        public IActionResult Index ()
        {
            if (_bannerService.GetAll( ).Count( ) != 0)
            {

                return View(new Banner( )
                {
                    Product = _productService.GetProductForDetailById(_bannerService.GetAll( )[0].ProductId),
                    Slogan = _bannerService.GetAll( )[0].Slogan
                });
            }
            return View( );
        }
        public IActionResult Create ()
        {
            ViewBag.AllProducts = _productService.GetAll( );
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( BannerModel model )
        {
            if (ModelState.IsValid)
            {
                Banner banner = new Banner( )
                {
                    ProductId = model.ProductId,
                    Slogan = model.Slogan,
                };
                _bannerService.Create(banner);
                return RedirectToAction("Index", "Banner");
            }
            return View( );
        }
        public IActionResult Edit ()
        {
            ViewBag.AllProducts = _productService.GetAll( );
            return View(new BannerModel( )
            {
                Slogan = _bannerService.GetAll( )[0].Slogan
            });
        }
        [HttpPost]
        public IActionResult Edit ( BannerModel model )
        {
            if (ModelState.IsValid)
            {
                Banner banner = _bannerService.GetAll( )[0];
                banner.ProductId = model.ProductId;
                banner.Slogan = model.Slogan;
                _bannerService.Update(banner);
                return RedirectToAction("Index", "Banner");
            }
            return View( );
        }
        public IActionResult Delete ()
        {
            Banner banner = _bannerService.GetAll( )[0];
            _bannerService.Delete(banner);
            return RedirectToAction("Index", "Banner");
        }

    }
}
