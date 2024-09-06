using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateMenuItemMealTimeDtoValidator : AbstractValidator<UpdateMenuItemMealTimeDto>
    {
        private readonly ASPContext _context;

        public UpdateMenuItemMealTimeDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.MenuItemId)
                .NotEmpty()
                .WithMessage("Menu item id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.MenuItemId)
                        .Must(id => _context.MenuItems.Any(m => m.Id == id))
                        .WithMessage(dto => $"Menu item with id {dto.MenuItemId} does not exist in database.");
                });

            RuleFor(x => x.MealTimeId)
               .NotEmpty()
               .WithMessage("Meal time id is required")
               .Must(MealTimeExists)
               .WithMessage("Meal time with provided id does not exist in database."); ;
        }

        private bool MealTimeExists(int id)
        {
            return _context.MealTimes.Any(m => m.Id == id);
        }
    }
}
