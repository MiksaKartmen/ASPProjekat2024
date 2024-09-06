using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetOneReservationQuery : EfUseCase, IGetOneReservationQuery
    {
        public EfGetOneReservationQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 51;

        public string Name => "Get one reservation";

        public string Description => "Get one reservation";

        public ReservationDto Execute(int search)
        {
            var query = Context.Reservations.AsQueryable();

            var reservation = query.Where(x => x.Id == search).FirstOrDefault();
            return new ReservationDto
            {
                Id = reservation.Id,
                Name = reservation.Name,
                Surname = reservation.Surname,
                Email = reservation.Email,
                Phone = reservation.Phone,
                Date = reservation.Date,
                People = reservation.People,
                TableId = reservation.TableId,
            };
        }
    }
}
