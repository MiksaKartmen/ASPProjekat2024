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
    public class EfDeleteTableCommand : EfUseCase, IDeleteTableCommand
    {
        private readonly DeleteTableDtoValidator _validator;
        public EfDeleteTableCommand(ASPContext context, DeleteTableDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 39;

        public string Name => "Delete table";

        public string Description => "Delete table";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var table = Context.Tables.Find(obj.Id);
            table.Reservations.Clear();

            Context.Tables.Remove(table);
            Context.SaveChanges();
        }
    }
}
