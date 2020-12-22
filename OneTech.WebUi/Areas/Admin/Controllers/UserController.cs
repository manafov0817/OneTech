using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public UserController ( RoleManager<IdentityRole> roleManager,
                                UserManager<User> userManager )
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index ()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> Edit ( string userId )
        {

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roles;


                return View(new UserEdit( )
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }

            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public async Task<IActionResult> Edit ( UserEdit model,string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except( userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>( ));


                        return RedirectToAction("Index","User");
                    }
                }
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }
    }
}