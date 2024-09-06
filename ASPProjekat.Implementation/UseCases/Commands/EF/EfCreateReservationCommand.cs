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
    public class EfCreateReservationCommand : EfUseCase, ICreateReservationCommand
    {
        private readonly CreateReservationDtoValidator _validator;
        public EfCreateReservationCommand(ASPContext context, CreateReservationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 53;

        public string Name => "Create reservation";

        public string Description => "Create reservation";

        public void Execute(CreateReservationDto obj)
        {
           _validator.ValidateAndThrow(obj);

            if(DateTime.Now > obj.Date)
            {
                throw new ValidationException("Reservation date can't be in the past!");
            }

            var reservationTable = Context.Tables.Where(x => x.Capacity >= obj.People).FirstOrDefault();

            if (reservationTable == null)
            {
                throw new ValidationException($"We currently don't have a table that can store {obj.People} people.");
            }

            var reservation = Context.Reservations.Where(x => x.TableId == reservationTable.Id && x.Date.AddHours(2) > obj.Date).FirstOrDefault();

            if (reservation != null)
            {
                throw new ValidationException($"This table is booked from {reservation.Date} to {reservation.Date.AddHours(2)}");
            }

            

            Context.Reservations.Add(new Reservation
            {
                Name = obj.Name,
                Surname = obj.Surname,
                Email = obj.Email,
                Date = obj.Date,
                Phone = obj.Phone,
                People = obj.People,
                TableId = reservationTable.Id,
            });

            Context.SaveChanges();
        }
    }
}
