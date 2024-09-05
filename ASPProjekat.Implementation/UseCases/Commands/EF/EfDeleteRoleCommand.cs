using ASPProjekat.Application.DTO;
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
    public class EfDeleteRoleCommand : EfUseCase, IDeleteRoleCommand
    {
        private readonly DeleteRoleDtoValidator _validator;
        public EfDeleteRoleCommand(ASPContext context, DeleteRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "Delete role";

        public string Description => "Delete role";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var role = Context.Roles.Find(obj.Id);

            Context.Roles.Remove(role);
            Context.SaveChanges();
        }
    }
}
