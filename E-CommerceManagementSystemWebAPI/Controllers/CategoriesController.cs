using E_CommerceData;
using E_CommerceData.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceManagementSystemWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var categories = context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            using E_CommerceManagementSystemContext context = new E_CommerceManagementSystemContext();
            var category = context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
            return Ok(category);
        }
    }
}
