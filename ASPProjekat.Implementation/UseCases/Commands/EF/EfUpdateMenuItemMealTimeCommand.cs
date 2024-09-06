using ASPProjekat.Application.DTO.Updates;
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
    public class EfUpdateMenuItemMealTimeCommand : EfUseCase, IUpdateMenuItemMealTimeCommand
    {
        private readonly UpdateMenuItemMealTimeDtoValidator _validator;
        public EfUpdateMenuItemMealTimeCommand(ASPContext context, UpdateMenuItemMealTimeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 47;

        public string Name => "Update menuItemMealTime";

        public string Description => "Update menuItemMealTime";

        public void Execute(UpdateMenuItemMealTimeDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var menuItemMealTime = Context.MenuItemMealTimes.Find(obj.Id);

            menuItemMealTime.MenuItemId = obj.MenuItemId;
            menuItemMealTime.MealTimeId = obj.MealTimeId;

            Context.SaveChanges();
        }
    }
}
