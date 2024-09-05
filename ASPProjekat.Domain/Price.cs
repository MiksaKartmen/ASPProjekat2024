using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class Price : Entity
    {
        public decimal Ammount { get; set; }
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}
