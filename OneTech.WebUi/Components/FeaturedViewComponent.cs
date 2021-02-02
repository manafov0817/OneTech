using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class FeaturedViewComponent : ViewComponent
    {
        private readonly IFeaturedProductService _featuredProductService;
        private readonly IBestRatedProductService _bestRatedProductService;
        private readonly IDealOfWeekProductService _dealOfWeekProductService;
        private readonly IOnSaleProductService _onSaleProductService;
        private readonly IProductService _productService;
        public FeaturedViewComponent ( IFeaturedProductService featuredProductService,
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
        public IViewComponentResult Invoke ()
        {
            List<DealOfWeekProduct> DealOfWeekProducts = _dealOfWeekProductService.GetAllProducts( );
            List<BestRatedProduct> BestRatedProducts = _bestRatedProductService.GetAllProducts( );
            List<OnSaleProduct> OnSaleProducts = _onSaleProductService.GetAllProducts( );
            List<FeaturedProduct> FeaturedProducts = _featuredProductService.GetAllProducts( );

            List<Product> dealOfWeekProducts = new List<Product>( );
            List<Product> bestRatedProducts = new List<Product>( );
            List<Product> onSaleProducts = new List<Product>( );
            List<Product> featuredProducts = new List<Product>( );
            foreach (DealOfWeekProduct dealOfWeekProduct in DealOfWeekProducts)
            {
                dealOfWeekProducts.Add(_productService.GetProductForDetailById(dealOfWeekProduct.ProductId));
            }
            foreach (BestRatedProduct bestRatedProduct in BestRatedProducts)
            {
                bestRatedProducts.Add(_productService.GetProductForDetailById(bestRatedProduct.ProductId));
            }
            foreach (OnSaleProduct onSaleProduct in OnSaleProducts)
            {
                onSaleProducts.Add(_productService.GetProductForDetailById(onSaleProduct.ProductId));
            }
            foreach (FeaturedProduct featuredProduct in FeaturedProducts)
            {
                featuredProducts.Add(_productService.GetProductForDetailById(featuredProduct.ProductId));
            }
            FeaturedModel model = new FeaturedModel( )
            {
                DealOfWeekProducts=dealOfWeekProducts,
                BestRatedProducts=bestRatedProducts,
                OnSaleProducts=onSaleProducts,
                FeaturedProducts=featuredProducts,
            };

            return View(model);
        }
    }
}
