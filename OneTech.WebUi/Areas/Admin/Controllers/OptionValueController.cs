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
    public class OptionValueController : Controller
    {
        private readonly IOptionValueService _optionValueService;
        private readonly IOptionService _optionService;
        public OptionValueController ( IOptionValueService optionValueService, IOptionService optionService )
        {
            _optionValueService = optionValueService;
            _optionService = optionService;
        }
        public IActionResult Index ()
        {
            return View(_optionValueService.GetAllWithOptions( ));
        }

        public IActionResult Create ()
        {
            ViewBag.Options = _optionService.GetAll( );
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( OptionValueModel model )
        {
            if (ModelState.IsValid)
            {
                OptionValue optionValue = new OptionValue( )
                {
                    Name = model.Name,
                    OptionId = model.OptionId,
                };
                _optionValueService.Create(optionValue);
                return RedirectToAction("Index", "OptionValue");
            }
            ViewBag.Options = _optionService.GetAll( );
            return View(model);
        }
        public IActionResult Edit ( int optionValueId )
        {
            if (optionValueId != 0)
            {
                OptionValue optionValue = _optionValueService.GetById(optionValueId);

                OptionValueEditModel model = new OptionValueEditModel( )
                {
                    Name = optionValue.Name,
                    Id = optionValue.Id,
                    OptionId = optionValue.OptionId
                };
                ViewBag.Options = _optionService.GetAll( );
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( OptionValueEditModel model )
        {
            if (ModelState.IsValid)
            {
                OptionValue optionValue = _optionValueService.GetById(model.Id);
                optionValue.Name = model.Name;
                optionValue.OptionId = model.OptionId;
                _optionValueService.Update(optionValue);
                return RedirectToAction("Index", "OptionValue");
            }
            ViewBag.Options = _optionService.GetAll( );
            return View(model);
        }
        public IActionResult Delete ( int optionValueId )
        {
            if (optionValueId != 0)
            {
                _optionValueService.Delete(_optionValueService.GetById(optionValueId));
                return RedirectToAction("Index", "OptionValue");
            }
            return View( );

        }
    }
}
