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
    public class EfUpdateGalleryImageCommand : EfUseCase, IUpdateGalleryImageCommand
    {
        private readonly UpdateGalleryImageDtoValidator _validator;
        public EfUpdateGalleryImageCommand(ASPContext context, UpdateGalleryImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "Update image";

        public string Description => "Update image";

        public void Execute(UpdateGalleryImageDto obj)
        {
            _validator.ValidateAndThrow(obj);
            if (obj.Src != null)
            {
                var extension = Path.GetExtension(obj.Src.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    obj.Src.CopyTo(fs);
                }

                var picture1 = Context.GalleryImages.Find(obj.Id);
                picture1.Src = "/images/" + filename;


                Context.SaveChanges();
            }
        }
    }
}
