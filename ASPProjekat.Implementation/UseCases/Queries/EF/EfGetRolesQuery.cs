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
    public class EfGetRolesQuery : EfUseCase, IGetRolesQuery
    {
        public EfGetRolesQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Get roles";

        public string Description => "Get roles";

        public IEnumerable<RoleDto> Execute(BaseSearch search)
        {
            var query = Context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
