using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IMainCategoryService _mainCategoryService;
        public SubCategoryController ( ISubCategoryService subCategoryService,
                                       ICategoryService categoryService,
                                       IMainCategoryService mainCategoryService )
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _mainCategoryService = mainCategoryService;
        }


        public IActionResult Index ()
        {
            return View(_subCategoryService.GetAllSubCategoriesWithCategoryAndMainCategory( ));
        }

        public IActionResult Create ()
        {
            SubCategoryAddModel subCategoryAddModel = new SubCategoryAddModel( )
            {
                MainCategories = _mainCategoryService.GetAll( )
            };

            return View(subCategoryAddModel);
        }
        [HttpPost]
        public IActionResult Create ( SubCategoryAddModel model )
        {
            if (ModelState.IsValid)
            {
                SubCategory subCategory = new SubCategory( )
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };
                _subCategoryService.Create(subCategory);
                return RedirectToAction("Index", "SubCategory");
            }

            List<MainCategory> mainCategories = _mainCategoryService.GetAll( );
            model.MainCategories = mainCategories;
            return View(model);
        }


        public IActionResult Edit ( int subCategoryId )
        {
            if (subCategoryId != 0)
            {
                SubCategory subCategory = _subCategoryService.GetSubCategoryWithCategoryAndMainCategorybyId(subCategoryId);
                SubCategoryEditModel model = new SubCategoryEditModel( )
                {
                    SubCategoryId = subCategoryId,
                    Name = subCategory.Name,
                    Description = subCategory.Description,
                    CategoryId = subCategory.CategoryId,
                    MainCategoryId = subCategory.Category.MainCategoryId,
                    MainCategories = _mainCategoryService.GetAll( )
                };
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( SubCategoryEditModel model )
        {
            if (ModelState.IsValid)
            {
                SubCategory subCategory = _subCategoryService.GetById(model.SubCategoryId);
                subCategory.Name = model.Name;
                subCategory.Description = model.Description;
                subCategory.CategoryId = model.CategoryId;
                _subCategoryService.Update(subCategory);
                return RedirectToAction("Index", "SubCategory");
            }
            return View(model);
        }


        public IActionResult Delete ( int subCategoryId )

        {
            if (subCategoryId != 0)
            {
                _subCategoryService.Delete(_subCategoryService.GetById(subCategoryId));
                return RedirectToAction("Index", "SubCategory");
            }
            return View(subCategoryId);
        }


        [HttpPost]
        public JsonResult FillCategory ( int id )
        {
            if (id != 0)
            {
                List<Category> categories = _categoryService.GetCategoriesByMainCategoryId(id);
                return Json(new
                {
                    status = 200,
                    data = categories
                });
            }
            else
            {
                return Json(new
                {
                    status = 400
                });
            }
        }
    }
}
