using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Gets
{
    public class AuditLogDto : BaseDto
    {
        public string User { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
