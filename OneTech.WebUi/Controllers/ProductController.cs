using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRelateService _productRelateService;
        public ProductController ( IProductService productService,
                                   IProductRelateService productRelateService )
        {
            _productService = productService;
            _productRelateService = productRelateService;
        }
        public IActionResult Index ( int productId )
        {
            Product product = _productService.GetProductForDetailById(productId);

            if (product!=null && product.ProductRelate != null)
            {
                List<ProductRelate> productRelates = _productRelateService.GetAllByGivenRelateId(product.ProductRelate.RelateId);
                List<Product> products = new List<Product>( );


                foreach (ProductRelate productRelate in productRelates)
                {
                    if (productRelate.ProductId != productId)
                    {
                        Product colorProduct = _productService.GetProductForDetailById(productRelate.ProductId);
                        products.Add(colorProduct);
                    }
                }
                return View(
                           new ProductModel( )
                           {
                               Product = product,
                               Products = products,
                           }
                );
            }
            return
                View(
                          new ProductModel( )
                          {
                              Product = product,
                          }
                    );
        }

        public async Task<IActionResult> GetProductsFromRestApi()
        {
            var products = new List<Product>();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:817/api/products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(products);
        }
    }
}
