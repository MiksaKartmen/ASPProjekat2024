using ASPProjekat.Application.DTO.Insert;
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
    public class EfCreateGalleryCommand : EfUseCase, ICreateGalleryCommand
    {
        private readonly CreateGalleryDtoValidator _validator;
        public EfCreateGalleryCommand(ASPContext context, CreateGalleryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Create gallery";

        public string Description => "Create gallery";

        public void Execute(CreateGalleryDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.Galleries.Add(new Gallery
            {
                Title = obj.Title,
            });

            Context.SaveChanges();
        }
    }
}
