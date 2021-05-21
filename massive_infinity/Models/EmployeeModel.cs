using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace massive_infinity.Models
{
    public class EmployeeModel
    {
        public Guid ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Guid Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
