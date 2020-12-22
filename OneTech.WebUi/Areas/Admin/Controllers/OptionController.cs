using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
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
    public class OptionController : Controller
    {
        private readonly IOptionService _optionService;
        public OptionController ( IOptionService optionService )
        {
            _optionService = optionService;
        }
        public IActionResult Index ()
        {
            return View(_optionService.GetAll( ));
        }
        public IActionResult Create ()
        {
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( OptionModel model )
        {
            if (ModelState.IsValid)
            {
                Option option = new Option( )
                {
                    Name = model.Name,
                };
                _optionService.Create(option);
                return RedirectToAction("Index", "Option");
            }
            return View(model);
        }
        public IActionResult Edit ( int optionId )
        {
            if (optionId != 0)
            {
                Option option = _optionService.GetById(optionId);
                OptionEditModel model = new OptionEditModel( )
                {
                    Id = option.Id,
                    Name = option.Name
                };
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( OptionEditModel model )
        {
            if (ModelState.IsValid)
            {
                Option option = _optionService.GetById(model.Id);
                option.Name = model.Name;
                _optionService.Update(option);
                return RedirectToAction("Index", "Option");
            }
            return View(model);
        }
        public IActionResult Delete ( int optionId )
        {
            if (optionId != 0)
            {
                _optionService.Delete(_optionService.GetById(optionId));
                return RedirectToAction("Index", "Option");
            }
            return View();
        }
    }
}
