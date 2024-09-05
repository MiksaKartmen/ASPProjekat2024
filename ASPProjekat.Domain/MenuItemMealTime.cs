using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class MenuItemMealTime : Entity
    {
        public int MealTimeId { get; set; }
        public int MenuItemId { get; set; }

        public virtual MealTime MealTime { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
