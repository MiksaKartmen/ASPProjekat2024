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
    public class EfCreateEmployeeCommand : EfUseCase, ICreateEmployeeCommand
    {
        private CreateEmployeeDtoValidator _validator;

        public EfCreateEmployeeCommand(ASPContext context, CreateEmployeeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Create employee";

        public string Description => "Create employee";

        public void Execute(CreateEmployeeDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.Employees.Add(new Employee
            {
                Name = obj.Name,
                Surname = obj.Surname,
                Biography = obj.Biography,
                Image = obj.Image,
                EmployeeRoleId = obj.EmployeeRoleId,
            });
            Context.SaveChanges();
        }
    }
}
