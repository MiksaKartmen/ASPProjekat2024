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
    public class EfGetEmployeesQuery : EfUseCase, IGetEmployeesQuery
    {
        public EfGetEmployeesQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get employees";

        public string Description => "Get employees";

        public IEnumerable<EmployeeDto> Execute(BaseSearch search)
        {
            var query = Context.Employees.AsQueryable();

            if (string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Surname.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Biography = x.Biography,
                Image = x.Image,
                EmployeeRole = x.EmployeeRole.Name
            }).ToList();
        }
    }
}
