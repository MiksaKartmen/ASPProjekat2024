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
    public class EfUpdateReservationCommand : EfUseCase, IUpdateReservationCommand
    {
        private readonly UpdateReservationDtoValidator _validator;
        public EfUpdateReservationCommand(ASPContext context, UpdateReservationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 59;

        public string Name => "Update reservation";

        public string Description => "Update reservation";

        public void Execute(UpdateReservationDto obj)
        {
            _validator.ValidateAndThrow(obj);

            if (DateTime.Now > obj.Date)
            {
                throw new ValidationException("Reservation date can't be in the past!");
            }

            var reservationTable = Context.Tables.Where(x => x.Capacity >= obj.People).FirstOrDefault();

            if (reservationTable == null)
            {
                throw new ValidationException($"We currently don't have a table that can store {obj.People} people.");
            }

            var reservation = Context.Reservations.Where(x => x.TableId == reservationTable.Id && x.Date.AddHours(2) > obj.Date && x.Id != obj.Id).FirstOrDefault();

            if (reservation != null)
            {
                throw new ValidationException($"This table is booked from {reservation.Date} to {reservation.Date.AddHours(2)}");
            }

            var reservationObj = Context.Reservations.Find(obj.Id);

            reservationObj.Name = obj.Name;
            reservationObj.Surname = obj.Surname;
            reservationObj.Email = obj.Email;
            reservationObj.Phone = obj.Phone;
            reservationObj.TableId = reservationTable.Id;
            reservationObj.Date = obj.Date;

            Context.SaveChanges();

        }
    }
}
