using ASPProjekat.Application.DTO;
using ASPProjekat.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class DeleteMenuCategoryDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;

        public DeleteMenuCategoryDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(Exists)
                .WithMessage("Category with an id of {PropertyValue} does not exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(NotUsed)
                        .WithMessage("Category with an id of {PropertyValue} is already in use.");
                });
        }
        private bool Exists(int id)
        {
            return _context.MenuCategories.Any(x => x.Id == id);
        }

        private bool NotUsed(int id)
        {
            return !_context.MenuCategories.Any(x => x.SubCategory == id);
        }
    }
}
