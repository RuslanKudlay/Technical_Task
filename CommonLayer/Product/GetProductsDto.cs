using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Product
{
    public record GetProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
    }
}
