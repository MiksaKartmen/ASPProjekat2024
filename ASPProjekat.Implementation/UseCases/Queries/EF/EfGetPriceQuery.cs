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
    public class EfGetPriceQuery : EfUseCase, IGetPriceQuery
    {
        public EfGetPriceQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Get price";

        public string Description => "Get price";

        public IEnumerable<PriceDto> Execute(PriceSearch search)
        {
            var query = Context.Prices.AsQueryable();
            if (search.Price != null)
            {
                query = query.Where(x => x.Ammount == search.Price);
            }

            return query.Select(x => new PriceDto
            {
                Id = x.Id,
                Ammount = x.Ammount,
                MenuItemId = x.MenuItemId
            }).ToList();
        }
    }
}
