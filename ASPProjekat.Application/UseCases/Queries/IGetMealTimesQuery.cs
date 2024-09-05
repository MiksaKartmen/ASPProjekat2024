using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.UseCases.Queries
{
    public interface IGetMealTimesQuery : IQuery<BaseSearch, IEnumerable<MealTimeDto>>
    {
    }
}
