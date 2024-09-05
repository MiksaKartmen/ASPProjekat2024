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
    public class EfCreateEmployeeRoleCommand : EfUseCase, ICreateEmployeeRoleCommand
    {
        private CreateEmployeeRoleDtoValidator _validator;

        public EfCreateEmployeeRoleCommand(ASPContext context, CreateEmployeeRoleDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Create employee role";

        public string Description => "Create employee role";

        public void Execute(CreateEmployeeRoleDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.EmployeeRoles.Add(new EmployeeRole
            {
                Name = obj.Name,
            });
            Context.SaveChanges();
        }
    }
}
