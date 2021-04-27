using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Business.Concrete;
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
    public class MainCategoryController : Controller
    {
        private readonly IMainCategoryService _mainCategoryService;
        public MainCategoryController ( IMainCategoryService mainCategoryService )
        {
            _mainCategoryService = mainCategoryService;
        }
        public IActionResult Index ()
        {
            return View(_mainCategoryService.GetAll( ));
        }

        public IActionResult Create ()
        {
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( MainCategoryModel model )
        {
            if (ModelState.IsValid)
            {
                MainCategory mainCategory = new MainCategory( )
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _mainCategoryService.Create(mainCategory);
                return RedirectToAction("Index", "MainCategory");
            }
            return View( );
        }

        public IActionResult Edit ( int mainCategoryId )
        {
            MainCategory mainCategory = _mainCategoryService.GetById(mainCategoryId);

            MainCategoryEditModel model = new MainCategoryEditModel( )
            {
                Id = mainCategoryId,
                Name = mainCategory.Name,
                Description = mainCategory.Description
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit ( MainCategoryEditModel model )
        {
            if (ModelState.IsValid)
            {
                MainCategory mainCategory = _mainCategoryService.GetById(model.Id);
                mainCategory.Name = model.Name;
                mainCategory.Description = model.Description;
                _mainCategoryService.Update(mainCategory);
                return RedirectToAction("Index", "MainCategory");

            }
            return View(model);
        }

        public IActionResult Delete ( int mainCategoryId )
        {
            if (mainCategoryId != 0)
            {
                _mainCategoryService.Delete(_mainCategoryService.GetById(mainCategoryId));
                return RedirectToAction("Index", "MainCategory");
            }

            return View( );
        }
    }
}
