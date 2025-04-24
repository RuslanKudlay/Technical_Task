using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
