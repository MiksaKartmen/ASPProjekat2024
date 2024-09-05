using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfCreateMenuItemMealTimeCommand : EfUseCase, ICreateMenuItemMealTimeCommand
    {
        private readonly CreateMenuItemMealTimeDtoValidator _validator;
        public EfCreateMenuItemMealTimeCommand(ASPContext context, CreateMenuItemMealTimeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 45;

        public string Name => "Create menuItemMealTime";

        public string Description => "Create menuItemMealTime";

        public void Execute(CreateMenuItemMealTimeDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.MenuItemMealTimes.Add(new MenuItemMealTime
            {
                MenuItemId = obj.MenuItemId,
                MealTimeId = obj.MealTimeId,
            });

            Context.SaveChanges();
        }
    }
}
