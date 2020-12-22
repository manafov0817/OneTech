using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.WebUi.Areas.Admin.Models;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandModelController : Controller
    {
        private readonly IBrandModelService _brandModelService;
        private readonly IBrandService _brandService;
        public BrandModelController ( IBrandModelService brandModelService,
                                       IBrandService brandService )
        {
            _brandModelService = brandModelService;
            _brandService = brandService;
        }
        public IActionResult Index ()
        {
            return View(_brandModelService.GetBrandModelsWithBrands( ));
        }

        public IActionResult Create ()
        {
            ViewBag.Brands = _brandService.GetAll( );
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( BrandModelModel model )
        {
            if (ModelState.IsValid)
            {
                Entity.Models.BrandModel brandModel = new Entity.Models.BrandModel( )
                {
                    ModelName = model.Name,
                    Description = model.Description,
                    BrandId = model.BrandId
                };
                _brandModelService.Create(brandModel);

                return RedirectToAction("Index", "BrandModel");
            }
            ViewBag.Brands = _brandService.GetAll( );
            return View(model);
        }

        public IActionResult Edit ( int brandModelId )
        {
            ViewBag.Brands = _brandService.GetAll( );
            Entity.Models.BrandModel brandModel = _brandModelService.GetById(brandModelId);
            BrandModelModel model = new BrandModelModel( )
            {
                Id = brandModelId,
                BrandId = brandModel.BrandId,
                Description = brandModel.Description,
                Name = brandModel.ModelName
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit ( BrandModelModel model )
        {
            if (ModelState.IsValid)
            {

                Entity.Models.BrandModel brandModel = _brandModelService.GetById(model.Id);
                brandModel.ModelName = model.Name;
                brandModel.Description = model.Description;
                brandModel.BrandId = model.BrandId;
                _brandModelService.Update(brandModel);
                return RedirectToAction("Index", "BrandModel");
            }
            ViewBag.Brands = _brandService.GetAll( );
            return View(model);
        }
        public IActionResult Delete ( int brandModelId )
        {
            if (brandModelId != 0)
            {
                _brandModelService.Delete(_brandModelService.GetById(brandModelId));
                return RedirectToAction("Index", "BrandModel");
            }
            return View( ); 
        }
    }
}
