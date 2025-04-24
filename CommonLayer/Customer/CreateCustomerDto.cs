using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Customer
{
    public record CreateCustomerDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
