using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateMenuItemMealTimeDtoValidator : AbstractValidator<CreateMenuItemMealTimeDto>
    {
        private readonly ASPContext _context;
        public CreateMenuItemMealTimeDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.MealTimeId)
                .Must(MealTimeExists)
                .WithMessage("Meal time with an id  does not exist.");


            RuleFor(x => x.MenuItemId)
                .Must(MenuItemExists)
                .WithMessage("Menu item with an id does not exist.");


        }
        public bool MealTimeExists(int mealTimeId)
        {
            return _context.MealTimes.Any(x => x.Id == mealTimeId);
        }
        public bool MenuItemExists(int menuItemId)
        {
            return _context.MenuItems.Any(x => x.Id == menuItemId);
        }
    }
}
