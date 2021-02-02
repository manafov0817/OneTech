using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.ComponentModels;
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
    public class FeaturedController : Controller
    {
        private readonly IFeaturedProductService _featuredProductService;
        private readonly IBestRatedProductService _bestRatedProductService;
        private readonly IDealOfWeekProductService _dealOfWeekProductService;
        private readonly IOnSaleProductService _onSaleProductService;
        private readonly IProductService _productService;
        public FeaturedController ( IFeaturedProductService featuredProductService,
                                    IBestRatedProductService bestRatedProductService,
                                    IDealOfWeekProductService dealOfWeekProductService,
                                    IOnSaleProductService onSaleProductService,
                                    IProductService productService )
        {
            _featuredProductService = featuredProductService;
            _bestRatedProductService = bestRatedProductService;
            _dealOfWeekProductService = dealOfWeekProductService;
            _onSaleProductService = onSaleProductService;
            _productService = productService;
        }

        public IActionResult Index ()
        {
            FeaturedModel model = new FeaturedModel( )
            {
                DealOfWeekProducts = _dealOfWeekProductService.GetAllProducts( ),
                BestRatedProducts = _bestRatedProductService.GetAllProducts( ),
                OnSaleProducts = _onSaleProductService.GetAllProducts( ),
                FeaturedProducts = _featuredProductService.GetAllProducts( ),
            };
            return View(model);
        }
        public IActionResult Create ( string productType )
        {
            if (productType == "osp")
            {
                List<Product> products = _productService.GetAllDiscountedProducts( );
                List<OnSaleProduct> onSaleProducts = _onSaleProductService.GetAllProducts( );

                foreach (OnSaleProduct onSale in onSaleProducts)
                {
                    foreach (Product product in products.ToList())
                    {
                        if (product.Id == onSale.ProductId)
                        {
                            products.Remove(product);
                        }
                    }                    
                }
                ViewBag.AllProducts = products;

                return View(new FeaturedAddModel
                {
                    FeatureType = "osp"
                });
            }
            if (productType == "dow")
            {
                List<Product> products = _productService.GetAllDiscountedProducts( );
                List<DealOfWeekProduct> dealOfWeekProducts = _dealOfWeekProductService.GetAllProducts( );

                foreach (DealOfWeekProduct dealOfWeekProduct in dealOfWeekProducts)
                {
                    foreach (Product product in products.ToList( ))
                    {
                        if (product.Id == dealOfWeekProduct.ProductId)
                        {
                            products.Remove(product);
                        }
                    }
                }
                ViewBag.AllProducts = products;

                return View(new FeaturedAddModel
                {
                    FeatureType = "dow"
                });
            }
            if (productType == "f")
            {
                List<Product> products = _productService.GetAll( );
                List<FeaturedProduct> featuredProducts = _featuredProductService.GetAllProducts( );

                foreach (FeaturedProduct featuredProduct in featuredProducts)
                {
                    foreach (Product product in products.ToList( ))
                    {
                        if (product.Id == featuredProduct.ProductId)
                        {
                            products.Remove(product);
                        }
                    }
                }
                ViewBag.AllProducts = products;
                return View(new FeaturedAddModel
                {
                    FeatureType = "f"
                });
            }
            if (productType == "br")
            {
                List<Product> products = _productService.GetAll( );
                List<BestRatedProduct> bestRatedProducts = _bestRatedProductService.GetAllProducts( );

                foreach (BestRatedProduct bestRatedProduct in bestRatedProducts)
                {
                    foreach (Product product in products.ToList( ))
                    {
                        if (product.Id == bestRatedProduct.ProductId)
                        {
                            products.Remove(product);
                        }
                    }
                }
                ViewBag.AllProducts = products;
                return View(new FeaturedAddModel
                {
                    FeatureType = "br"
                });
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( FeaturedAddModel model )
        {
            if (model.FeatureType == "dow")
            {
                DealOfWeekProduct product = new DealOfWeekProduct( )
                {
                    ProductId = model.ProductId
                };
                _dealOfWeekProductService.Create(product);
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "f")
            {
                FeaturedProduct product = new FeaturedProduct( )
                {
                    ProductId = model.ProductId
                };
                _featuredProductService.Create(product);
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "osp")
            {
                OnSaleProduct product = new OnSaleProduct( )
                {
                    ProductId = model.ProductId
                };
                _onSaleProductService.Create(product);
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "br")
            {
                BestRatedProduct product = new BestRatedProduct( )
                {
                    ProductId = model.ProductId
                };
                _bestRatedProductService.Create(product);
                return RedirectToAction("Index", "Featured");
            }
            return View( );
        }
  
        public IActionResult Delete ( FeaturedAddModel model )
        {
            if (model.FeatureType == "dow")
            {
                _dealOfWeekProductService.Delete(_dealOfWeekProductService.GetById(model.ProductId));
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "f")
            {
                _featuredProductService.Delete(_featuredProductService.GetById(model.ProductId));
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "osp")
            {
                _onSaleProductService.Delete(_onSaleProductService.GetById(model.ProductId));
                return RedirectToAction("Index", "Featured");
            }
            if (model.FeatureType == "br")
            {
                _bestRatedProductService.Delete(_bestRatedProductService.GetById(model.ProductId));
                return RedirectToAction("Index", "Featured");
            }
            return View( );
        }
    }
}
