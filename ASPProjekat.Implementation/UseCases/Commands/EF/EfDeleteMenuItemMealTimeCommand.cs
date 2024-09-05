using ASPProjekat.Application.DTO;
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
    public class EfDeleteMenuItemMealTimeCommand : EfUseCase, IDeleteMenuItemMealTimeCommand
    {
        private readonly DeleteMenuItemMealTimeDtoValidator _validator;

        public EfDeleteMenuItemMealTimeCommand(ASPContext context, DeleteMenuItemMealTimeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 46;

        public string Name => "Delete menuItemMealTime";

        public string Description => "Delete menuItemMealTime";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var menuItemMealTime = Context.MenuItemMealTimes.Find(obj.Id);

            Context.MenuItemMealTimes.Remove(menuItemMealTime);
            Context.SaveChanges();
        }
    }
}
