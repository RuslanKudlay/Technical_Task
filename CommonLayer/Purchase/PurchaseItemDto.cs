using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Purchase
{
    public record PurchaseItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
