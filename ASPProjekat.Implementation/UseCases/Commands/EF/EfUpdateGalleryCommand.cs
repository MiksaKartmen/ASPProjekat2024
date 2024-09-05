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
    public class EfUpdateGalleryCommand : EfUseCase, IUpdateGalleryCommand
    {
        private readonly UpdateGalleryDtoValidator _validator;
        public EfUpdateGalleryCommand(ASPContext context, UpdateGalleryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Update gallery";

        public string Description => "Update gallery";

        public void Execute(UpdateGalleryDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var gallery = Context.Galleries.Find(obj.Id);

            gallery.Title = obj.Title;

            Context.SaveChanges();
        }
    }
}
