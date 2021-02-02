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

            if (product.ProductRelate != null)
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
    }
}
