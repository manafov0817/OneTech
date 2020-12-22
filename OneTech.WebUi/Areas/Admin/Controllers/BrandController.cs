using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController ( IBrandService brandService )
        {
            _brandService = brandService;
        }

        public IActionResult Index ()
        {
            return View(_brandService.GetAll( ));
        }
        public IActionResult Create ()
        {
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( Models.BrandModel model )
        {
            if (ModelState.IsValid)
            {
                Brand brand = new Brand( )
                {
                    BrandName = model.Name,
                    Description = model.Description,
                    ImageUrl = model.Photo.FileName
                };

                var path = Path.Combine(Directory.GetCurrentDirectory( ), "wwwroot", "img", "Brands"
                                                                , model.Photo.FileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }
                _brandService.Create(brand);
                return RedirectToAction("Index", "Brand");
            }
            return View( );
        }
        public IActionResult Edit ( int brandId )
        {
            if (brandId != 0)
            {
                Brand brand = _brandService.GetById(brandId);
                BrandEditModel model = new BrandEditModel( )
                {
                    Id = brand.Id,
                    Name = brand.BrandName,
                    Description = brand.Description,
                };
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( BrandEditModel model )
        {
            if (ModelState.IsValid)
            {
                Brand brand = _brandService.GetById(model.Id);
                brand.BrandName = model.Name;
                brand.Description = model.Description;
                brand.ImageUrl = model.Photo.FileName;
                var oldPath = Path.Combine(Directory.GetCurrentDirectory( ), "wwwroot", "img", "Brands"
                                                                , brand.ImageUrl);
                var newPath = Path.Combine(Directory.GetCurrentDirectory( ), "wwwroot", "img", "Brands"
                                                                , model.Photo.FileName);


                FileInfo fi = new FileInfo(oldPath);
                if (fi != null)
                {
                    System.IO.File.Delete(brand.ImageUrl);
                    fi.Delete( );
                }

                using (FileStream fs = new FileStream(newPath, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }

                _brandService.Update(brand);

                return RedirectToAction("Index", "Brand");
            }
            return View( );
        }
        public IActionResult Delete ( int brandId )
        {
            if (brandId != 0)
            {
                Brand brand = _brandService.GetById(brandId);
                string path = Path.Combine(Directory.GetCurrentDirectory( )
                                                , "wwwroot", "img", "Brands"
                                                , brand.ImageUrl);
                FileInfo fi = new FileInfo(path);
                if (fi != null)
                {
                    System.IO.File.Delete(brand.ImageUrl);
                    fi.Delete( );
                }
                _brandService.Delete(brand);
                return RedirectToAction("Index", "Brand");
            }
            return View( );
        }
    }
}
