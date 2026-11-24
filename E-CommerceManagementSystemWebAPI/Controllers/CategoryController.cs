using E_CommerceData;
using E_CommerceData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceManagementSystemWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetAllCategories()
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var categories = context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
            return Ok(categories);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById(int id)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var category = context.Categories
                .Where(c => c.Id == id).Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
