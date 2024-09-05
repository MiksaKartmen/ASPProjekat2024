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
    public class EfGetOneMenuCategoryQuery : EfUseCase, IGetOneMenuCategoryQuery
    {
        public EfGetOneMenuCategoryQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Get one category";

        public string Description => "Get one category";

        public MenuCategoryDto Execute(int search)
        {
            var query = Context.MenuCategories.AsQueryable();

            var category = query.Where(x => x.Id == search).FirstOrDefault();
            return new MenuCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                SubCategory = category.SubCategory == null ? 0 : (int)category.SubCategory
            };
        }
    }
}
