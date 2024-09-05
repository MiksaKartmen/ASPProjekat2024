using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Gets
{
    public class EmployeeDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        public string EmployeeRole { get; set; }
    }

   
}
