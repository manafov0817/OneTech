using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var products = _categoryService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var p = _categoryService.GetById(id);
            if (p == null)
            {
                return NotFound(); // 404
            }
            return Ok(p); // 200
        }

        [HttpPost]
        public IActionResult AddProduct(Category model)
        {
            _categoryService.Create(model);
            return CreatedAtAction(nameof(GetCategory), new { id = model.Id }, model);
        }
    }
}
