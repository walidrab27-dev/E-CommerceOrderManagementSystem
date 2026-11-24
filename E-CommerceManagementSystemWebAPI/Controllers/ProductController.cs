using Microsoft.AspNetCore.Mvc;
using E_CommerceData;
using E_CommerceData.DTOs;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceManagementSystemWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetAllProducts()
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var products = context.Products.Select(p=>new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable
            }).ToList();
            return Ok(products);
        }
        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var product = context.Products
                .Where(p=>p.Id==id).Select(p=>new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable
            }).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("GetProductByName/{name}")]
        public IActionResult GetProductByname(string name)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var product = context.Products
                .Where(p=>p.Name==name).Select(p=>new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable
            }).FirstOrDefault();
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("GetProductBycategory/{categoryName}")]
        public IActionResult GetProductBycategory(string categoryName)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var products = context.Products.Include(a => a.Category)
                .Where(a => a.Category.Name == categoryName).Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    IsAvailable = p.IsAvailable
                }).ToList();
            if(products.Count==0)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("GetProductByAvailablity/{isAvailable}")]
        public IActionResult GetProductByAvailablity(bool isAvailable)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var products = context.Products
                .Where(a=>a.IsAvailable==isAvailable).Select(p=>new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable
            }).ToList();
            if (products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }
    }
}
