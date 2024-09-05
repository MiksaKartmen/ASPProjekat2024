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
    public class EfUpdateEmployeeCommand : EfUseCase, IUpdateEmployeeCommand
    {
        private readonly UpdateEmployeeDtoValidator _validator;
        public EfUpdateEmployeeCommand(ASPContext context, UpdateEmployeeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Update employee";

        public string Description => "Update employee";

        public void Execute(UpdateEmployeeDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var employee = Context.Employees.Find(obj.Id);
            employee.Name = obj.Name;
            employee.Surname = obj.Surname;
            employee.Biography = obj.Biography;
            employee.Image = obj.Image;
            employee.EmployeeRoleId = obj.EmployeeRoleId;

            Context.SaveChanges();
        }
    }
}
