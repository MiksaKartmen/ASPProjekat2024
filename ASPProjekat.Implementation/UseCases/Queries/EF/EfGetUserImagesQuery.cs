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
    public class EfGetUserImagesQuery : EfUseCase, IGetUserImagesQuery
    {
        public EfGetUserImagesQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Get user images";

        public string Description => "Get user images";

        public IEnumerable<UserImageDto> Execute(BaseSearch search)
        {
            var query = Context.UserImages.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.User.Name.ToLower().Contains(search.Keyword.ToLower()) || x.User.Surname.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new UserImageDto
            {
                Id = x.Id,
                Src = x.Src,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
