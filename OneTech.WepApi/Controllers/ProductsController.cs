using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Entity.Models;
using OneTech.WepApi.DTO;

namespace OneTech.WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (Product product in products)
            {
                productDTOs.Add(ProductDTOMaker(product));
            }
            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductDTOMaker(product)); // 200
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            _productService.Create(model);
            return CreatedAtAction(nameof(GetProduct), new { id = model.Id }, ProductDTOMaker(model));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Delete(product);
            return NoContent();
        }

        private ProductDTO ProductDTOMaker(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                PurchasePrice = product.PurchasePrice,
                SellingPrice = product.SellingPrice,
                Description = product.Description,
                DiscountStart = product.DiscountStart,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }
    }
}