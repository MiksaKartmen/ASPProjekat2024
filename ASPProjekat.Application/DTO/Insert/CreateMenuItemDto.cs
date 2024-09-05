using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Insert
{
    public class CreateMenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int MenuCategoryId { get; set; }
        public decimal Price { get; set; }

    }

    public class MenuItemDto : BaseDto
    {
        public string Name { get; set; }
        public string MenuCategoryName { get; set; }
        public List<MealTimeDto> MealTimes { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int MenuCategoryId { get; set; }
        public decimal Price { get; set; }
    }

    public class MealTimeDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan TimeFrom { get; set; }
        [DataType(DataType.Time)]

        public TimeSpan TimeTo { get; set; }
    }
}
