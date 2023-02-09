using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Data.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string SurName { get; set; } = "";
        public string? Job { get; set; }
        public string IdentityNumber { get; set; } = "";
        public string? PhoneNumber { get; set; }
    }
}
