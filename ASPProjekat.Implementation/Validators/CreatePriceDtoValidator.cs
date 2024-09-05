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
    public class CreatePriceDtoValidator : AbstractValidator<CreatePriceDto>
    {
        private readonly ASPContext _context;

        public CreatePriceDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Ammount)
                .NotEmpty()
                .WithMessage("Price ammount is required");

            RuleFor(x => x.MenuItemId)
                .NotEmpty()
                .WithMessage("Menu item is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.MenuItemId)
                        .Must((dto, id) => _context.MenuItems.Any(b => b.Id == id))
                        .WithMessage(dto => $"Menu item with this id doesn't exist in the database.");
                });
        }
    }
}
