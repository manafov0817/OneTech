using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneTech.Business.Abstract;
using OneTech.WebUi.EmailServices;
using OneTech.WebUi.Identity;
using OneTech.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;
        public AccountController ( UserManager<User> userManager,
                                   SignInManager<User> signinManager,
                                   IEmailSender emailSender,
                                   ICartService cartService )
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Login ()
        {
            return View( );
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login ( LoginModel model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username);


            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(model.Username);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Please confirm your email");
                return View(model);
            }




            var result = await _signinManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register ()
        {
            return View( );
        }
        [HttpPost]
        public async Task<IActionResult> Register ( RegisterModel model )
        {
            if (!ModelState.IsValid)
            {
                return View( );
            }

            var user = new User( )
            {
                FirstName = model.Name,
                LastName = model.Surname,
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code,
                });
                await _emailSender.SendEmailAsync(model.Email, "Zəhmət olmasa hesabınızı doğrulayın", $"Hesabınızı doğrulamaq üçün verilən linkə <a href='https://localhost:44342{url}'>daxil olun</a>");
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail ( string userId, string token )
        {
            if (userId == null || token == null)
            {
                CreateMessage("ivalid token", "danger");

                return View( );
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                CreateMessage("ther is not user with this credentials", "danger");
                return View( );
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                //_cartService.InitializeCart(user.Id);
                CreateMessage("sucess", "success");
                return View( );
            }
            return View( );
        }


        [HttpGet]
        public IActionResult ForgotPassword ()
        {
            return View( );
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword ( string Email )
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View( );
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                return View( );
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code,
            });

            await _emailSender.SendEmailAsync(Email, "Şifrənizi yeniləyin", $"Şifrənizi yeniləmək üçün verilən linkə <a href='https://localhost:44342{url}'>daxil olun</a>");

            return View( );
        }


        public IActionResult ResetPassword ( string userId, string token )
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel { Token = token };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword ( ResetPasswordModel model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }


        public async Task<IActionResult> Logout ()
        {
            await _signinManager.SignOutAsync( );
            return RedirectToAction("Index", "Home");
        }
        private void CreateMessage ( string message, string alerttype )
        {
            var msg = new AlertMessage( )
            {
                Message = message,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
