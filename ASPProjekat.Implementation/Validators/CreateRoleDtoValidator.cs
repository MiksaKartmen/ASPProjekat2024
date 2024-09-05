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
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        private readonly ASPContext _context;

        public CreateRoleDtoValidator(ASPContext context)
        {
            _context = context;
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Role name is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                        .Must((dto, name) => !_context.Roles.Any(b => b.Name == name))
                        .WithMessage(dto => $"Role with name {dto.Name} already exists in database.");
                });
        }

    }
}
