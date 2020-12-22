using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTech.Business.Abstract;
using OneTech.Data.Concrete.EfCore;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMainCategoryService _mainCategoryService;
        public CategoryController ( ICategoryService categoryService,
                                    IMainCategoryService mainCategoryService )
        {
            _categoryService = categoryService;
            _mainCategoryService = mainCategoryService;
        }
      
        public IActionResult Index ()
        {
            List<Category> categories = _categoryService.GetAllCategoriesWithMainCategory( );

            return View(categories);
        }


        public IActionResult Create ()
        {
            List<MainCategory> mainCategories = _mainCategoryService.GetAll( );
            CategoryAddModel model = new CategoryAddModel( )
            {
                MainCategory = mainCategories
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create ( CategoryAddModel model )
        {
            if (ModelState.IsValid)
            {
                Category category = new Category( )
                {
                    MainCategoryId = model.MainCategoryId,
                    Name = model.Name,
                    Description = model.Description
                };
                _categoryService.Create(category);
                return RedirectToAction("Index", "Category");
            }
            List<MainCategory> mainCategories = _mainCategoryService.GetAll( );
            model.MainCategory = mainCategories;
            return View(model);
        }


        public IActionResult Edit ( int categoryId )
        {
            if (categoryId != 0)
            {
                Category category = _categoryService.GetById(categoryId);
                List<MainCategory> mainCategories = _mainCategoryService.GetAll( );
                CategoryEditModel model = new CategoryEditModel( )
                {
                    CategoryId = categoryId,
                    MainCategoryId = category.MainCategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    MainCategory = mainCategories
                };
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( CategoryEditModel model )
        {
            if (ModelState.IsValid)
            {
                Category category = _categoryService.GetById(model.CategoryId);
                category.Name = model.Name;
                category.Description = model.Description;
                category.MainCategoryId = model.MainCategoryId;
                _categoryService.Update(category);
                return RedirectToAction("Index", "Category");
            }
            List<MainCategory> mainCategories = _mainCategoryService.GetAll( );
            model.MainCategory = mainCategories;
            return View(model);
        }

        public IActionResult Delete(int categoryId )
        {
            if (categoryId != 0)
            {
                _categoryService.Delete(_categoryService.GetById(categoryId));
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
