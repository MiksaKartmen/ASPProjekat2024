using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateGalleryImageDtoValidator : AbstractValidator<UpdateGalleryImageDto>
    {
        private readonly ASPContext _context;
        public UpdateGalleryImageDtoValidator(ASPContext context)
        {
            _context = context;


            RuleFor(x => x.GalleryId)
                .Must(GalleryExists)
                .WithMessage("Gallery with an id  does not exist.");
        }
        public bool GalleryExists(int galleryId)
        {
            return _context.Galleries.Any(x => x.Id == galleryId);
        }
    }
}
