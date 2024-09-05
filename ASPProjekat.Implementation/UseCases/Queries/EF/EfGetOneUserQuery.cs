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
    public class EfGetOneUserQuery : EfUseCase, IGetOneUserQuery
    {
        public EfGetOneUserQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Get one user";

        public string Description => "Get one user";

        public UserDto Execute(int search)
        {
            var query = Context.Users.AsQueryable();

            var user = query.Where(x => x.Id == search).FirstOrDefault();
      
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
               
            };
        }
    }
}
