using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Searches
{
    public class AuditLogsSearch
    {
        public string? User { get; set; }
        public string? UseCaseName { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }

        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 12;
    }
}
