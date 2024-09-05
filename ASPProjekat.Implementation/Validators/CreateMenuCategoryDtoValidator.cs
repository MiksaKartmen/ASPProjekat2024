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
    public class CreateMenuCategoryDtoValidator : AbstractValidator<CreateMenuCategoryDto>
    {
        public CreateMenuCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MinimumLength(3).WithMessage("Category name must have at least 3 characters.")
                .MaximumLength(30).WithMessage("Category name must have at most 30 characters.");


        }
    }
}
