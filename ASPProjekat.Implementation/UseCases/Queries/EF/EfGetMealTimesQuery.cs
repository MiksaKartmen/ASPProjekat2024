using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetMealTimesQuery : EfUseCase, IGetMealTimesQuery
    {
        public EfGetMealTimesQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Get meal times";

        public string Description => "Get meal times";

        public IEnumerable<MealTimeDto> Execute(BaseSearch search)
        {
            var query = Context.MealTimes.AsQueryable();

            if (string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new MealTimeDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                TimeFrom = x.TimeFrom,
                TimeTo = x.TimeTo,
            }).ToList();
        }
    }
}
