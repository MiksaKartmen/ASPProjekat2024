using ASPProjekat.Application.DTO.Insert;
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
    public class EfCreateRoleCommand : EfUseCase, ICreateRoleCommand
    {
        private readonly CreateRoleDtoValidator _validator;
        public EfCreateRoleCommand(ASPContext context, CreateRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Create role";

        public string Description => "Create role";

        public void Execute(CreateRoleDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.Roles.Add(new Role
            {
                Name = obj.Name,
            });
            Context.SaveChanges();
        }
    }
}
