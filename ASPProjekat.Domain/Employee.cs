using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        public int EmployeeRoleId { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }
    }
}
