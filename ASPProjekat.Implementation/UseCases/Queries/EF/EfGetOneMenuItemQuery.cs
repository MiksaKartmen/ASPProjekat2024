using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetOneMenuItemQuery : EfUseCase, IGetOneMenuItemQuery
    {
        public EfGetOneMenuItemQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Get one menu item";

        public string Description => "Get one menu item";

        public MenuItemDto Execute(int search)
        {
            var query = Context.MenuItems.AsQueryable();

            var menuItem = query.Where(x => x.Id == search).FirstOrDefault();
            return new MenuItemDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                //MenuCategoryName = menuItem.MenuCategory.Name,
                Image = menuItem.Image,
                MenuCategoryId = menuItem.MenuCategoryId,
                Price = menuItem.Prices.Select(y => y.Ammount).FirstOrDefault(),
                MealTimes = menuItem.MenuItemMealTimes.Select(y => new MealTimeDto
                {
                    Id = y.MealTimeId,
                    Name = y.MealTime.Name,
                    Description = y.MealTime.Description,
                    TimeFrom = y.MealTime.TimeFrom,
                    TimeTo = y.MealTime.TimeTo,
                }).ToList(),
            };
        }
    }
}
