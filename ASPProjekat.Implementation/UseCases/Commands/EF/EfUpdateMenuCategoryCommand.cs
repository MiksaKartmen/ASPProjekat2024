using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfUpdateMenuCategoryCommand : EfUseCase, IUpdateMenuCategoryCommand
    {
        private readonly UpdateMenuCategoryDtoValidator _validator;
        public EfUpdateMenuCategoryCommand(ASPContext context, UpdateMenuCategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Update category";

        public string Description => "Update category";

        public void Execute(UpdateMenuCategoryDto obj)
        {
            _validator.ValidateAndThrow(obj);
            
            var category = Context.MenuCategories.Find(obj.Id);
            category.Name = obj.Name;
            category.SubCategory = obj.SubCategory;
            Context.SaveChanges();
        }
    }
}
