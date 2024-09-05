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
    public class CreateMenuItemDtoValidator : AbstractValidator<CreateMenuItemDto>
    {
        private readonly ASPContext _context;
        public CreateMenuItemDtoValidator(ASPContext context) 
        { 
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Menu item name is required.");
            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Menu item name is required.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Menu item name is required.");
            RuleFor(x => x.MenuCategoryId)
                .NotEmpty()
                .WithMessage("Menu item name is required.")
                .Must(x => context.MenuCategories.Any(s => s.Id == x))
                .WithMessage("Manu category with the provided id doesn't exist.");
        }
    }
}
