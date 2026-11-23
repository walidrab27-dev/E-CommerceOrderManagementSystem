using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceData.Entities
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime PaymentDate { get; set; }
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
