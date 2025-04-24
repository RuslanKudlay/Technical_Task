using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.DTOs
{
    public class PopularCustomerCategotyDto
    {
        public string Category { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
    }
}
