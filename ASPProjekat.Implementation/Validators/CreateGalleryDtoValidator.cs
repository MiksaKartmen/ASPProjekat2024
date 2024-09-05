using ASPProjekat.Application.DTO.Insert;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateGalleryDtoValidator : AbstractValidator<CreateGalleryDto>
    {
        public CreateGalleryDtoValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Gallery title is required");
        }
    }
}
