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
    public class EfUpdateMenuItemCommand : EfUseCase, IUpdateMenuItemCommand
    {
        private UpdateMenuItemDtoValidator _validator;
        public EfUpdateMenuItemCommand(ASPContext context, UpdateMenuItemDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update menu item";

        public string Description => "Update menu item";

        public void Execute(UpdateMenuItemDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var menuItem = Context.MenuItems.Find(obj.Id);
            menuItem.Name = obj.Name;
            menuItem.Description = obj.Description;
            menuItem.Image = obj.Image;
            menuItem.MenuCategoryId = obj.MenuCategoryId;

            Context.SaveChanges();
        }
    }
}
