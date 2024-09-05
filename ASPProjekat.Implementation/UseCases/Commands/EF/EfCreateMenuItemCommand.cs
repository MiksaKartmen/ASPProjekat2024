using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using Azure.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfCreateMenuItemCommand : EfUseCase, ICreateMenuItemCommand
    {
        private CreateMenuItemDtoValidator _validator;
        public EfCreateMenuItemCommand(ASPContext context, CreateMenuItemDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create menu item";

        public string Description => "Create menu item";

        public void Execute(CreateMenuItemDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var price = new Price
            {
                Ammount = obj.Price
            };

            Context.MenuItems.Add(new MenuItem
            {
                Name = obj.Name,
                Description = obj.Description,
                Image = obj.Image,
                MenuCategoryId = obj.MenuCategoryId,
                Prices = new List<Price> { price }
            });
            Context.SaveChanges();
        }
    }
}
