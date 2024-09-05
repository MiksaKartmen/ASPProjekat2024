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
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly ASPContext _context;
        public CreateUserDtoValidator(ASPContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !_context.Users.Any(u => u.Email == x))
                .WithMessage("Email is already in use.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Minimum eight characters, at least one uppercase letter, one lowercase letter and one number:");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^\+[0-9]{11,}$")
                .WithMessage("Phone number must be in format +38123456789");

        }
    }
}
