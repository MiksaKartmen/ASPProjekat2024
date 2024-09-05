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
    public class DeleteEmployeeDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;
        public DeleteEmployeeDtoValidator(ASPContext context) 
        {
            _context = context;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => _context.Employees.Any(y => y.Id == x)).WithMessage("Employee with provided id doesn't exist.");
        }

    }
}
