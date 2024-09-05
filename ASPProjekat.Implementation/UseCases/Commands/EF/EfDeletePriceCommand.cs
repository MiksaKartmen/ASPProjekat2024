using ASPProjekat.Application.DTO;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using Azure.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfDeletePriceCommand : EfUseCase, IDeletePriceCommand
    {
        private readonly DeletePriceDtoValidator _validator;

        public EfDeletePriceCommand(ASPContext context, DeletePriceDtoValidator validator) : base(context)
        {
            _validator = validator;

        }

        public int Id => 27;

        public string Name => "Delete price";

        public string Description => "Delete price";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var price = Context.Prices.Find(obj.Id);
            Context.Prices.Remove(price);
            Context.SaveChanges();
        }
    }
}
