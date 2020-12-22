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
    public class ColorController : Controller
    {
        private readonly IOptionValueService _optionValueService;
        private readonly IOptionService _optionService;
        public ColorController ( IOptionValueService optionValueService, IOptionService optionService )
        {
            _optionValueService = optionValueService;
            _optionService = optionService;
        }
        public IActionResult Index ()
        {
            List<OptionValue> colors = _optionValueService.GetAllColors( );
            return View(colors);
        }


        public IActionResult Create ()
        {
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( ColorModel model )
        {
            if (ModelState.IsValid)
            {
                string color = "";
                if (model.HexCode.Contains("#"))
                {
                    color = model.Name + model.HexCode;
                }
                else
                {
                    color = model.Name + "#" + model.HexCode;
                }

                Option option = _optionService.GetByName("color");
                OptionValue optionValue = new OptionValue( )
                {
                    Name = color,
                    OptionId = option.Id
                };
                _optionValueService.Create(optionValue);
                return RedirectToAction("Index", "Color");
            }
            return View(model);
        }


        public IActionResult Edit ( int colorId )
        {
            if (colorId != 0)
            {
                OptionValue optionValue = _optionValueService.GetById(colorId);

                ColorEditModel model = new ColorEditModel( )
                {
                    Id = optionValue.Id,
                    Name = optionValue.Name.Split("#")[0],
                    HexCode = optionValue.Name.Split("#")[1],
                };
                ViewBag.Name = optionValue.Name;
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult Edit ( ColorEditModel model )
        {
            if (ModelState.IsValid)
            {
                string color = "";
                if (model.HexCode.Contains("#"))
                {
                    color = model.Name + model.HexCode;
                }
                else
                {
                    color = model.Name + "#" + model.HexCode;
                }
                OptionValue optionValue = _optionValueService.GetById(model.Id);

                optionValue.Name = color;
                _optionValueService.Update(optionValue);
                return RedirectToAction("Index", "Color");
            }
            return View(model);
        }


        public IActionResult Delete ( int colorId )
        {
            if (colorId != 0)
            {
                _optionValueService.Delete(_optionValueService.GetById(colorId));
                return RedirectToAction("Index", "Color");
            }
            return View(colorId);
        }
    }
}