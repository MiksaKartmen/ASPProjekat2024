using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using Azure.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfCreateMenuCategoryCommand : EfUseCase, ICreateMenuCategoryCommand
    {
        private CreateMenuCategoryDtoValidator _validator;

        public EfCreateMenuCategoryCommand(ASPContext context, CreateMenuCategoryDtoValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create category";

        public string Description => "Create new category";

        public void Execute(CreateMenuCategoryDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.MenuCategories.Add(new Domain.MenuCategory
            {
                Name = obj.Name,
                SubCategory = obj.SubCategory,
            });
            Context.SaveChanges();
        }
    }
}
