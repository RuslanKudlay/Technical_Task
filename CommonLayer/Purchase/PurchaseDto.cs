using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Purchase
{
    public record PurchaseDto
    {
        public Guid CustomerId { get; set; } = Guid.Empty;
        public List<PurchaseItemDto> PurchaseItemDtos { get; set; } = new ();
    }
}
