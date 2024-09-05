using ASPProjekat.Application.DTO;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class DeleteGalleryImageDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;
        public DeleteGalleryImageDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Picture Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.GalleryImages.Any(p => p.Id == id))
                        .WithMessage("Picture with an id of {PropertyValue} doesn't exist.");
                });
        }
    }
}
