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
            new Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 1200, ImageUrl = "laptop.jpg" },
            new Product { Id = 2, Name = "Phone", Description = "Smartphone", Price = 800, ImageUrl = "phone.jpg" }
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
