using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class MenuCategory : Entity
    {
        public string Name { get; set; }
        public int? SubCategory { get; set; }

        public virtual MenuCategory Parent { get; set; }
        public virtual ICollection<MenuCategory> Children { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
    }
}
