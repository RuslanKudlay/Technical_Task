using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Purchase> Purchases { get; set; } = new();
    }
}
