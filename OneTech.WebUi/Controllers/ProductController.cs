using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController ( IProductService productService )
        {
            _productService = productService;
        }
        public IActionResult Index ( int productId )
        {
            return View( _productService.GetProductForDetailById(productId));
        }
    }
}
