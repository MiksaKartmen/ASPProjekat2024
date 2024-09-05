using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class MealTime : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }

        public virtual ICollection<MenuItemMealTime> MenuItemMealTime { get; set; } = new HashSet<MenuItemMealTime>();


    }
}
