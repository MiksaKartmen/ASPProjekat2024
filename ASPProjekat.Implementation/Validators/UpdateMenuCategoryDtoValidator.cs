using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateMenuCategoryDtoValidator : AbstractValidator<UpdateMenuCategoryDto>
    {
        private readonly ASPContext _context;

        public UpdateMenuCategoryDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                        .Must((dto, name) => !_context.MenuCategories.Any(b => b.Name == name && b.Id != dto.Id))
                        .WithMessage(dto => $"Category with name {dto.Name} already exists in database.");
                });
            RuleFor(x => x.Id).Must(id => _context.MenuCategories.Any(b => b.Id == id))
                .WithMessage("Category with provided id does not exist in database.");
        }
    }
}
