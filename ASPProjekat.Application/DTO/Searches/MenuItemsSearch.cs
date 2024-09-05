using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Searches
{
    public class MenuItemsSearch
    {
        public int? MenuCategoryId { get; set; }
        public int? SubCategory { get; set; }
        public List<int>? MealTimesId { get; set; }
        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 5;
    }
}
