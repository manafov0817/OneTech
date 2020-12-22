using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IOptionService _optionService;
        private readonly IOptionValueService _optionValueService;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        public ShopController ( IProductService productService,
                                ICategoryService categoryService,
                                ISubCategoryService subCategoryService,
                                IMainCategoryService mainCategoryService,
                                IOptionService optionService,
                                IOptionValueService optionValueService,
                                IBrandService brandService )
        {
            _productService = productService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mainCategoryService = mainCategoryService;
            _optionService = optionService;
            _optionValueService = optionValueService;
            _brandService = brandService;
        }

        public IActionResult Index ( string categoryId, int pageSize = 2, int pageNumber = 1 )
        {
            List<Product> products = new List<Product>( );
            string CategoryName = " ";
            if (categoryId.StartsWith("m"))
            {
                products = _productService
                             .GetProductsByMainCategoryId(Convert.ToInt32(categoryId.Substring(1)));

                CategoryName = _mainCategoryService.GetById(Convert.ToInt32(categoryId.Substring(1))).Name;
            }
            if (categoryId.StartsWith("c"))
            {
                products = _productService
                           .GetProductsByCategoryId(Convert.ToInt32(categoryId.Substring(1)));
                CategoryName = _categoryService.GetById(Convert.ToInt32(categoryId.Substring(1))).Name;
            }
            if (categoryId.StartsWith("s"))
            {
                products = _productService
                           .GetProductsBySubCategoryId(Convert.ToInt32(categoryId.Substring(1)));
                CategoryName = _subCategoryService.GetById(Convert.ToInt32(categoryId.Substring(1))).Name;

            }
            List<OptionValue> colors = _optionValueService.GetAllColors( );
            int count = products.Count( );
            products = products.Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize).ToList( );
            List<Brand> brands = _brandService.GetAll( );
            ShopModel model = new ShopModel( )
            {
                Products = products,
                PageSize = pageSize,
                ProductCount = count,
                Colors = colors,
                CategoryId = categoryId,
                Brands = brands,
                CategoryName = CategoryName
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductList ( int pageSize, int pageNumber, string categoryId, string[] colorIds, string[] brandIds )
        {
            List<Product> products = new List<Product>( );

            if (categoryId != null)
            {
                if (categoryId.StartsWith("m"))
                {
                    products = _productService
                                 .GetProductsByMainCategoryId(Convert.ToInt32(categoryId.Substring(1)));
                }
                if (categoryId.StartsWith("c"))
                {
                    products = _productService
                               .GetProductsByCategoryId(Convert.ToInt32(categoryId.Substring(1)));
                }
                if (categoryId.StartsWith("s"))
                {
                    products = _productService
                               .GetProductsBySubCategoryId(Convert.ToInt32(categoryId.Substring(1)));
                }
            }

            if (colorIds.Count( ) > 0)
            {
                List<Product> helperProducts1 = new List<Product>( );
                helperProducts1.AddRange(products);
                products.Clear( );
                foreach (string stringId in colorIds)
                {
                    int colorId = Convert.ToInt32(stringId);
                    List<Product> colorProducts = _productService.GetProductsByOptionValueId(colorId);
                    foreach (Product colorProduct in colorProducts)
                    {
                        var isIn = false;
                        foreach (var helperProduct in helperProducts1)
                        {
                            if (helperProduct.Id == colorProduct.Id)
                            {
                                isIn = true;
                            }
                        }
                        if (isIn && !products.Contains(colorProduct))
                        {
                            products.Add(colorProduct);
                        }
                    }
                }
            }

            if (brandIds.Count( ) > 0)
            {
                List<Product> helperProducts2 = new List<Product>( );
                helperProducts2.AddRange(products);
                products.Clear( );
                foreach (string stringId in brandIds)
                {
                    int brandId = Convert.ToInt32(stringId);
                    List<Product> brandProducts = _productService.GetProductsByBrandId(brandId);
                    foreach (Product brandProduct in brandProducts)
                    {
                        var isIn = false;
                        foreach (var helperProduct in helperProducts2)
                        {
                            if (helperProduct.Id == brandProduct.Id)
                            {
                                isIn = true;
                            }
                        }
                        if (isIn && !products.Contains(brandProduct))
                        {
                            products.Add(brandProduct);
                        }
                    }
                }
            }

            int productCount = products.Count( );
            products = products.Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToList( );
            var data = Newtonsoft.Json.JsonConvert.SerializeObject
                (
                     new
                     {
                         status = 200,
                         data = products,
                         productCount = productCount,
                     }, new Newtonsoft.Json.JsonSerializerSettings( )
                     {
                         ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                     }
                );
            return Json(data);
        }
    }
}
