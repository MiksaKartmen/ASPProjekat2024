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
    public class EfCreateGalleryImageCommand : EfUseCase ,ICreateGalleryImageCommand
    {
        private readonly CreateGalleryImageDtoValidator _validator;

        public EfCreateGalleryImageCommand(ASPContext context, CreateGalleryImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Create image";

        public string Description => "Create image";

        public void Execute(CreateGalleryImageDto obj)
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
                Context.GalleryImages.Add(new GalleryImage
                {
                    Src = "/images/" + filename,
                    GalleryId = obj.GalleryId,
                });

                Context.SaveChanges();

            }
        }
    }
}
