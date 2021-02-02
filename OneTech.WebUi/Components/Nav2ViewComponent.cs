using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Identity;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class Nav2ViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;
        private readonly IMainCategoryService _mainCategoryService;
        private UserManager<User> _userManager;
        public Nav2ViewComponent ( UserManager<User> userManager,
                                    ICategoryService categoryService,
                                    ISubCategoryService subCategoryService,
                                    IMainCategoryService mainCategoryService,
                                    ICartItemService cartItemService,
                                    ICartService cartService )
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mainCategoryService = mainCategoryService;
            _userManager = userManager;
            _cartItemService = cartItemService;
            _cartService = cartService;
        }
        public async Task<IViewComponentResult> InvokeAsync ()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Cart cart = _cartService.GetByUserId(user.Id);

                if (cart == null)
                {
                    _cartService.InitializeCart(user.Id);
                }

                List<CartItem> cartItems = _cartItemService.GetByCartId(cart.Id);
                decimal? price = 0;
                int count = 0;
                foreach (CartItem item in cartItems)
                {
                    price += item.Product.SellingPrice * item.Quantity;
                    count++;
                }

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

                Nav2Model model = new Nav2Model( )
                {
                    UserId = user.Id,
                    ItemCount = count,
                    ItemsTotal = (int)price,
                    MainCategories = modelMainCategories,
                    Categories = modelCategories,
                    SubCategories = modelSubCategories,
                };

                return View(model);
            }
            else
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

                Nav2Model model = new Nav2Model( )
                {
                    MainCategories = modelMainCategories,
                    Categories = modelCategories,
                    SubCategories = modelSubCategories,
                };
                return View(model);
            }
        }
    }
}
