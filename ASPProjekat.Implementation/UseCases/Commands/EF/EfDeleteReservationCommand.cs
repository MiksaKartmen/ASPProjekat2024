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
    public class EfDeleteReservationCommand : EfUseCase, IDeleteReservationCommand
    {
        private readonly DeleteReservationDtoValidator _validator;

        public EfDeleteReservationCommand(ASPContext context, DeleteReservationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 52;

        public string Name => "Delete reservation";

        public string Description => "Delete reservation";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var reservation = Context.Reservations.Find(obj.Id);
            Context.Reservations.Remove(reservation);
            Context.SaveChanges();
        }
    }
}
