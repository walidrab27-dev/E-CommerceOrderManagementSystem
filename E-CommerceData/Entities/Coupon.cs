using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceData.Entities
{
    public class Coupon : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
