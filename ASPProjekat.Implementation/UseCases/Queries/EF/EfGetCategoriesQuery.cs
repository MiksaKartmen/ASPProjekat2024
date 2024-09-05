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
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public int Id => 1;

        public string Name => "Search categories";

        public string Description => "Search categories using entity framework";

        public EfGetCategoriesQuery(ASPContext context) : base(context)
        {
        }

        public IEnumerable<MenuCategoryDto> Execute(BaseSearch search)
        {
            var query = Context.MenuCategories.AsQueryable();

            if (string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new MenuCategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                SubCategory = x.SubCategory == null ? 0 : (int)x.SubCategory
            }).ToList();
        }
    }
}
