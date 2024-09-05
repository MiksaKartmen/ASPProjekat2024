using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Gets
{
    public class UserImageDto : BaseDto
    {
        public string Src { get; set; }
        public int UserId { get; set; }
    }
}
