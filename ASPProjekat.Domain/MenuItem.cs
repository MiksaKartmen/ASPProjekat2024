using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class MenuItem : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int MenuCategoryId { get; set; }

        public virtual ICollection<MenuItemMealTime> MenuItemMealTimes { get; set; } = new HashSet<MenuItemMealTime>();
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>();
        public virtual MenuCategory MenuCategory { get; set; }


    }
}
