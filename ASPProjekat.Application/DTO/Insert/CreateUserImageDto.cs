using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Insert
{
    public class CreateUserImageDto
    {
        public IFormFile Src { get; set; }
        public int UserId { get; set; }
    }
}
