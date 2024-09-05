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
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        private readonly ASPContext _context; 
        public CreateEmployeeDtoValidator(ASPContext context) 
        { 
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Employee name is required.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Employee surname is required.");

            RuleFor(x => x.Biography)
                .NotEmpty()
                .WithMessage("Employee biography is required.");

            RuleFor(x => x.Image)
               .NotEmpty()
               .WithMessage("Employee image is required.");

            RuleFor(x => x.EmployeeRoleId)
               .NotEmpty()
               .WithMessage("Employee role is required.")
               .Must(x => context.EmployeeRoles.Any(s => s.Id == x))
               .WithMessage("Employee role with the provided id doesn't exist.");
        }
    }
}
