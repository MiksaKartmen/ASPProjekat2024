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
    public class EfUpdateTableCommand : EfUseCase, IUpdateTableCommand
    {
        private readonly UpdateTableDtoValidator _validator;
        public EfUpdateTableCommand(ASPContext context, UpdateTableDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "Update table";

        public string Description => "Update table";

        public void Execute(UpdateTableDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var table = Context.Tables.Find(obj.Id);
            table.Name = obj.Name;
            table.Capacity = obj.Capacity;

            Context.SaveChanges();
        }
    }
}
