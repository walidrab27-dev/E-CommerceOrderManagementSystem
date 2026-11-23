using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceData.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }        
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
