using ASPProjekat.Application.DTO.Updates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateGalleryDtoValidator : AbstractValidator<UpdateGalleryDto>
    {
        public UpdateGalleryDtoValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required");
        }
    }
}
