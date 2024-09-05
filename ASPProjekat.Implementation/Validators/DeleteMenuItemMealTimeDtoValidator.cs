using ASPProjekat.Application.DTO;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class DeleteMenuItemMealTimeDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;
        public DeleteMenuItemMealTimeDtoValidator(ASPContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => _context.MenuItemMealTimes.Any(mvs => mvs.Id == x)).WithMessage("Menu item for this meal time with provided id doesn't exist.");
        }
    }
}
