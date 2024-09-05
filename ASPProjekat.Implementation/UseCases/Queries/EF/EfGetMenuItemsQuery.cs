using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetMenuItemsQuery : EfUseCase, IGetMenuItemsQuery
    {
        public EfGetMenuItemsQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get menu items";

        public string Description => "Get menu items";

        public IEnumerable<MenuItemDto> Execute(MenuItemsSearch search)
        {
            var query = Context.MenuItems.AsQueryable();

            if(search.MenuCategoryId != null)
            {
                query = query.Where(x => x.MenuCategory.Id == search.MenuCategoryId);
            }
            if (search.SubCategory != null)
            {
                query = query.Where(x => x.MenuCategory.SubCategory == search.MenuCategoryId);
            }

            if (search.MealTimesId != null && search.MealTimesId.Any())
            {
                var mealTimes = Context.MealTimes
                    .Where(s => search.MealTimesId.Contains(s.Id))
                    .Select(s => new { s.Id, s.Name})
                    .ToList();

                var groupedMealTimeIds = mealTimes
                    .GroupBy(s => s.Id)
                    .ToList();

                foreach (var group in groupedMealTimeIds)
                {
                    var mealTimeIds = group.Select(g => g.Id).ToList();
                    query = query.Where(mealTime => mealTime.MenuItemMealTimes.Any(m => mealTimeIds.Contains(m.MealTimeId)));
                }
            }

            var skipCount = (search.Page.GetValueOrDefault(1) - 1) * search.ItemsPerPage.GetValueOrDefault(5);
            query = query.Skip(skipCount).Take(search.ItemsPerPage.GetValueOrDefault(5));

            var menuItems = query.Select(x => new MenuItemDto
            {
                Id = x.Id,
                Name = x.Name,
                MenuCategoryName = x.MenuCategory.Name,
                Description = x.Description,              
                Image = x.Image,
                MenuCategoryId = x.MenuCategory.Id,
                Price = x.Prices.Select(y => y.Ammount).FirstOrDefault(),
                MealTimes = x.MenuItemMealTimes.Select(y => new MealTimeDto
                {
                    Id = y.MealTimeId,
                    Name = y.MealTime.Name,
                    Description = y.MealTime.Description,
                    TimeFrom = y.MealTime.TimeFrom,
                    TimeTo = y.MealTime.TimeTo,
                }).ToList(),

            }).ToList();

            return menuItems;
        }
    }
}
