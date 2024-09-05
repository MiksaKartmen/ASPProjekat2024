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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Get users";

        public string Description => "Get users";

        public IEnumerable<UserDto> Execute(BaseSearch search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Surname.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Role = x.Role.Name,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
