using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Customer
{
    public record GetCustomersDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
