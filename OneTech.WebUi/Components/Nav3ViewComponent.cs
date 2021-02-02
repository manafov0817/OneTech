using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.WebUi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class Nav3ViewComponent : ViewComponent
    {
        private readonly IMainCategoryService _mainCategoryService;
        public Nav3ViewComponent ( IMainCategoryService mainCategoryService )
        {
            _mainCategoryService = mainCategoryService;
        }

        public IViewComponentResult Invoke ()
        {
            return View(_mainCategoryService.GetAllWithEverything( ));
        }
    }
}
