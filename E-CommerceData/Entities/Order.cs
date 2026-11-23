using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceData.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
