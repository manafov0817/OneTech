using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.ComponentModels;
using OneTech.WebUi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PopularCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IPopularCategoryService _popularCategoryService;
        public PopularCategoryController ( ICategoryService categoryService,
                                           ISubCategoryService subCategoryService,
                                           IMainCategoryService mainCategoryService,
                                           IPopularCategoryService popularCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mainCategoryService = mainCategoryService;
            _popularCategoryService = popularCategoryService;
        }
        public IActionResult Index ()
        {
            List<PopularCategory> popularCategories = _popularCategoryService.GetAll( );
            List<PopularCategoryModel> models = new List<PopularCategoryModel>( );
            foreach (PopularCategory popularCategory in popularCategories)
            {
                PopularCategoryModel model = new PopularCategoryModel( );
            }
            return View( );
        }
    }
}
