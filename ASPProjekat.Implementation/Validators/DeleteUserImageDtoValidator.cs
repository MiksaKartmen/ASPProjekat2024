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
    public class DeleteUserImageDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;
        public DeleteUserImageDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User image Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.UserImages.Any(p => p.Id == id))
                        .WithMessage("User image with an id of {PropertyValue} doesn't exist.");
                });
        }
    }
}
