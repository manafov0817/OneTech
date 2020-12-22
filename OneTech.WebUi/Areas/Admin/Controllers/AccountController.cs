using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneTech.WebUi.Areas.Admin.Models;
using OneTech.WebUi.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController ( UserManager<User> userManager,
                                                    SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login ()
        {
            return View( );
        }
        [HttpPost]
        public async Task<IActionResult> Login ( LoginModel model )
        {
            if (ModelState.IsValid)
            {
                User admin = await _userManager.FindByNameAsync(model.Email);
                if (admin == null)
                {
                    admin = await _userManager.FindByEmailAsync(model.Email);
                }
                if (admin == null)
                {
                    ModelState.AddModelError("", "User is not exists");
                    return View(model);
                }
                else
                {
                    bool isAdmin = await _userManager.IsInRoleAsync(admin, "Admin");
                    if (isAdmin)
                    {
                        var signInResult = await _signInManager.PasswordSignInAsync(admin, model.Password, false, false);
                        if (signInResult.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "User is not exists");
                            return View(model);

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You are not Admin");
                        return View(model);
                    }
                }
            }
            else
            {
                return View( );
            };
        }
    }
}
