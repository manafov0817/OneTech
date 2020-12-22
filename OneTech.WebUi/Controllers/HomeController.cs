using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController ( IProductService productService )
        {
            _productService = productService;
        }
        public IActionResult Index ()
        {
            return View( );
        }
    }
}
