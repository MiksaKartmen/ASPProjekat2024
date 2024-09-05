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
    public class EfDeleteMenuItemCommand : EfUseCase, IDeleteMenuItemCommand
    {
        private readonly DeleteMenuItemDtoValidator _validator;
        public EfDeleteMenuItemCommand(ASPContext context, DeleteMenuItemDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Delete menu item";

        public string Description => "Delete menu item";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var menuItem = Context.MenuItems.Find(obj.Id);
            menuItem.MenuItemMealTimes.Clear();
            menuItem.Prices.Clear();

            Context.MenuItems.Remove(menuItem);
            Context.SaveChanges();
        }
    }
}
