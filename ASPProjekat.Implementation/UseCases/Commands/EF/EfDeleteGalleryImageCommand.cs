using ASPProjekat.Application.DTO;
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
    public class EfDeleteGalleryImageCommand : EfUseCase, IDeleteGalleryImageCommand
    {
        private readonly DeleteGalleryImageDtoValidator _validator;

        public EfDeleteGalleryImageCommand(ASPContext context, DeleteGalleryImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Delete image";

        public string Description => "Delete image";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var picture = Context.GalleryImages.Find(obj.Id);
            Context.GalleryImages.Remove(picture);
            Context.SaveChanges();
        }
    }
}
