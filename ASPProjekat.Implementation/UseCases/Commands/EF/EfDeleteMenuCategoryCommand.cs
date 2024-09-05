using ASPProjekat.Application.DTO;
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
    public class EfDeleteMenuCategoryCommand : EfUseCase, IDeleteMenuCategoryCommand
    {
        private readonly DeleteMenuCategoryDtoValidator _validator;
        public EfDeleteMenuCategoryCommand(ASPContext context, DeleteMenuCategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Delete a category";

        public string Description => "Delete a category";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var category = Context.MenuCategories.Find(obj.Id);

            Context.MenuCategories.Remove(category);

            Context.SaveChanges();
        }
    }
}
