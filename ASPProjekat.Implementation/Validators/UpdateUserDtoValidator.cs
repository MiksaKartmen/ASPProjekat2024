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
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly ASPContext _context;

        public UpdateUserDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("First name is required")
                .MinimumLength(2).WithMessage("First name must have at least 2 characters");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Last name is required")
                .MinimumLength(2).WithMessage("Last name must have at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not in the correct format")
                .Must((dto, email) => !_context.Users.Any(u => u.Email == email && u.Id != dto.Id))
                .WithMessage("Email is already taken");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must have at least 6 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MinimumLength(9).WithMessage("Phone must have at least 9 characters");


        }
    }
}
