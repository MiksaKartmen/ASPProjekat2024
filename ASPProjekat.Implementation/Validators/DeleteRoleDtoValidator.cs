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
    public class DeleteRoleDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;

        public DeleteRoleDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(Exists)
                .WithMessage("Role with an id of {PropertyValue} does not exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(NotUsed)
                        .WithMessage("Role with an id of {PropertyValue} is already in use.");
                });
        }
        private bool Exists(int id)
        {
            return _context.Roles.Any(x => x.Id == id);
        }

        private bool NotUsed(int id)
        {
            return !_context.Users.Any(x => x.RoleId == id);
        }
    }
}
