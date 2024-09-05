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
    public class EfCreateTableCommand : EfUseCase, ICreateTableCommand
    {
        private readonly CreateTableDtoValidator _validator;
        public EfCreateTableCommand(ASPContext context, CreateTableDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 36;

        public string Name => "Create table";

        public string Description => "Create table";

        public void Execute(CreateTableDto obj)
        {
            _validator.ValidateAndThrow(obj);

            Context.Tables.Add(new Table
            {
                Name = obj.Name,
                Capacity = obj.Capacity,
            });

            Context.SaveChanges();
        }
    }
}
