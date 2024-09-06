using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetReservationsQuery : EfUseCase, IGetReservationsQuery
    {
        public EfGetReservationsQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 50;

        public string Name => "Get reservations";

        public string Description => "Get reservations";

        public IEnumerable<ReservationDto> Execute(BaseSearch search)
        {
            var query = Context.Reservations.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Surname.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ReservationDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Date = x.Date,
                TableId = x.TableId,
                People = x.People,
            });
        }
    }
}
