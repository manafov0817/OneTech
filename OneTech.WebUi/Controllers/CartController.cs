using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WebUi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    public class CartController : Controller
    {
        private ICartItemService _cartItemService;
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController ( ICartItemService cartItemService,
                                ICartService cartService,
                                UserManager<User> userManager )
        {
            _cartItemService = cartItemService;
            _userManager = userManager;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index ()
        {
            string currentUserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            if (currentUserId != null)
            {
                List<CartItem> cartItems = _cartItemService.GetByUserId(currentUserId);
                return View(cartItems);
            }
            return View( );
        }

        public async Task<IActionResult> AddToCart ( int producId, int productCount )
        {
            int myProductCount = 1;
            if (productCount > 1)
            {
                myProductCount = productCount;
            }
            if (producId != 0)
            {
                Cart cart = _cartService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);
                CartItem cartItem = new CartItem( )
                {
                    CartId = cart.Id,
                    ProductId = producId,
                    Quantity = myProductCount
                };
                List<CartItem> cartItems = _cartItemService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);
                foreach (CartItem item in cartItems)
                {
                    if (item.ProductId == producId)
                    {
                        item.Quantity += myProductCount;
                        _cartItemService.Update(item);
                        return RedirectToAction("Index", "Home");
                    }
                }
                _cartItemService.Create(cartItem);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<JsonResult> ChangeProductCountAjax ( int productId, int productCount )
        {
            if (productId != 0)
            {
                List<CartItem> cartItems = _cartItemService.GetByCartId(_cartService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id).Id);

                foreach (CartItem cartItem in cartItems)
                {
                    if (cartItem.ProductId == productId)
                    {
                        cartItem.Quantity = productCount;
                        _cartItemService.Update(cartItem);
                    }
                }
                return Json(new
                {
                    status = 200,
                });
            }
            return Json(new
            {
                status = 400,
            });
        }

        public async Task<JsonResult> AddToCartAjax ( int productId, int productCount )
        {
            int myProductCount = 1;

            if (productCount > 1)
            {
                myProductCount = productCount;
            }

            if (productId != 0)
            {
                Cart cart = _cartService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);

                CartItem cartItem = new CartItem( )
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = myProductCount
                };

                List<CartItem> cartItems = _cartItemService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);

                decimal? allProductsInCartPrice = 0;

                foreach (CartItem item in cartItems)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += myProductCount;
                        _cartItemService.Update(item);
                        cartItems = _cartItemService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);

                        foreach (CartItem citem in cartItems)
                        {
                            allProductsInCartPrice += citem.Product.SellingPrice * citem.Quantity;
                        }

                        return Json(new
                        {
                            status = 200,
                            productTypeCount = cartItems.Count( ),
                            allProductsInCartPrice = allProductsInCartPrice
                        });
                    }
                }
                _cartItemService.Create(cartItem);
                cartItems = _cartItemService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);

                foreach (CartItem item in cartItems)
                {
                    allProductsInCartPrice += item.Product.SellingPrice * item.Quantity;
                }

                return Json(new
                {
                    status = 200,
                    productTypeCount = cartItems.Count( ),
                    allProductsInCartPrice = allProductsInCartPrice
                });
            }
            return Json(new
            {
                status = 400,
            });
        }

        public async Task<JsonResult> RemoveFromCart ( int productId )
        {

            if (productId != 0)
            {
                Cart cart = _cartService.GetByUserId((await _userManager.GetUserAsync(HttpContext.User)).Id);

                List<CartItem> cartItems = _cartItemService.GetByCartId(cart.Id);

                foreach (CartItem item in cartItems)
                {
                    if (item.ProductId == productId)
                    {
                        _cartItemService.Delete(item);
                    }
                }              

                return Json(new
                {
                    status = 200,
                });
            }
            return Json(new
            {
                status = 400,
            });
        }
    }
}
