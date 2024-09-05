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
    public class EfDeleteEmployeeCommand : EfUseCase, IDeleteEmployeeCommand
    {
        private DeleteEmployeeDtoValidator _validator;
        public EfDeleteEmployeeCommand(ASPContext context, DeleteEmployeeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Delete Employee";

        public string Description => "Delete employee";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var employee = Context.Employees.Find(obj.Id);

            Context.Employees.Remove(employee);

            Context.SaveChanges();
        }
    }
}
