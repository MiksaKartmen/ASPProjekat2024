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
    public class EfCreatePriceCommand : EfUseCase, ICreatePriceCommand
    {
        private readonly CreatePriceDtoValidator _validator;
        public EfCreatePriceCommand(ASPContext context, CreatePriceDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Create price";

        public string Description => "Create price";

        public void Execute(CreatePriceDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.Prices.Add(new Price
            {
                Ammount = obj.Ammount,
                MenuItemId = obj.MenuItemId,
            });

            Context.SaveChanges();
        }
    }
}
