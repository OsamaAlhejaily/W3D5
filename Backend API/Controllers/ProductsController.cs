using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Description = "HP Pavilion Laptop", Price = 1200, ImageUrl = "./images/laptop.jpg" },
            new Product { Id = 2, Name = "Phone", Description = "Iphone 14", Price = 800, ImageUrl = "./images/phone.jpg"},
            new Product { Id = 3, Name = "Tablet", Description = "Lenovo Tab M10", Price = 1200, ImageUrl = "./images/tablet.jpg" },

        };

        [HttpGet]
        public IActionResult GetProducts() => Ok(products);

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
