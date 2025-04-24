using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.DTOs
{
    public record DayRecentCustomerDto
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
