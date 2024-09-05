using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        private readonly UpdateRoleDtoValidator _validator;
        public EfUpdateRoleCommand(ASPContext context, UpdateRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Update role";

        public string Description => "Update role";

        public void Execute(UpdateRoleDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var role = Context.Roles.Find(obj.Id);

            role.Name = obj.Name;

            Context.SaveChanges();
        }
    }
}
