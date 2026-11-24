using E_CommerceData.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceManagementSystemWebAPI.Controllers
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
