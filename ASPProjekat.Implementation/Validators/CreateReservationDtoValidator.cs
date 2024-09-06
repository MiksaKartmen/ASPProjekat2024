using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationDtoValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Surname is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required");
            RuleFor(x => x.People)
                .NotEmpty()
                .WithMessage("People is required");


        }
    }
}
