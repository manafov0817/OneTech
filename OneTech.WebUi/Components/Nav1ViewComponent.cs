using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Components
{
    public class Nav1ViewComponent : ViewComponent
    {
        private readonly IContactService _contactService;
        public Nav1ViewComponent ( IContactService contactService )
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke ()
        {

            return View( _contactService.GetAll());
        }
    }
}
