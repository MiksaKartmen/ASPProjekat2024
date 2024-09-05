using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetOneMealTimeQuery : EfUseCase, IGetOneMealTimeQuery
    {
        public EfGetOneMealTimeQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Get one meal time";

        public string Description => "Get one meal time";

        public MealTimeDto Execute(int search)
        {
            var query = Context.MealTimes.AsQueryable();
            var mealTime = query.Where(x => x.Id == search).FirstOrDefault();

            return new MealTimeDto
            {
                Id = mealTime.Id,
                Name = mealTime.Name,
                Description = mealTime.Description,
                TimeFrom = mealTime.TimeFrom,
                TimeTo = mealTime.TimeTo,
            };

        }
    }
}
