using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class Nav2ViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;

        public Nav2ViewComponent ( ICategoryService categoryService,
                                    ISubCategoryService subCategoryService,
                                    IMainCategoryService mainCategoryService )
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mainCategoryService = mainCategoryService;
        }

        public IViewComponentResult Invoke ()
        {
            List<MainCategory> mainCategories = _mainCategoryService.GetAllWithEverything( );
            List<Category> categories = _categoryService.GetAllWithEverything( );
            List<SubCategory> modelSubCategories = _subCategoryService.GetAllSubCategoriesWithCategoryAndMainCategory( );

            List<MainCategory> modelMainCategories = new List<MainCategory>( );
            List<Category> modelCategories = new List<Category>( );

            foreach (MainCategory mainCategory in mainCategories)
            {
                if (mainCategory.Categories.Count( ) == 0)
                {
                    modelMainCategories.Add(mainCategory);
                }
            }

            foreach (Category category in categories)
            {
                if (category.SubCategories.Count( ) == 0)
                {
                    modelCategories.Add(category);
                }
            }
            Nav2Model model = new Nav2Model( ) {
                MainCategories = modelMainCategories,
                Categories = modelCategories,
                SubCategories = modelSubCategories,
            };

            return View(model);
        }

    }
}
