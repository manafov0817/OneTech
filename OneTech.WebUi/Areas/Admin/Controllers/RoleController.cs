using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneTech.WebUi.Identity;
using OneTech.WebUi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public RoleController ( RoleManager<IdentityRole> roleManager,
                                UserManager<User> userManager )
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index ()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Create ()
        {

            return View( );
        }
        [HttpPost]
        public async Task<IActionResult> Create ( RoleModel model )
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View( );
        }

        [HttpGet]
        public async Task<IActionResult> Edit ( string RoleId )
        {
            var role = await _roleManager.FindByIdAsync(RoleId);

            var members = new List<User>( );
            var nonMembers = new List<User>( );

            foreach (var user in _userManager.Users.ToList( ))
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var model = new RoleEdit( )
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit ( RoleEditModel model )
        {
            string RoleId = "";
            if (ModelState.IsValid)
            {
                RoleId = model.RoleId;
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }



                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Edit", "Role", new { RoleId = RoleId });
        }
    }
}
