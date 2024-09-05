using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Gets
{
    public class PriceDto : BaseDto
    {
        public decimal Ammount { get; set; }
        public decimal MenuItemId { get; set; }
    }
}
