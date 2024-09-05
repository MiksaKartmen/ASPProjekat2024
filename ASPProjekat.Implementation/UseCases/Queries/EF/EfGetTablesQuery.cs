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
    public class EfGetTablesQuery : EfUseCase, IGetTablesQuery
    {
        public EfGetTablesQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Get tables";

        public string Description => "Get tables";

        public IEnumerable<TableDto> Execute(BaseSearch search)
        {
            var query = Context.Tables.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Capacity.ToString() == search.Keyword);
            }

            return query.Select(x => new TableDto
            {
                Id = x.Id,
                Name = x.Name,
                Capacity = x.Capacity,
            }).ToList();
        }
    }
}
