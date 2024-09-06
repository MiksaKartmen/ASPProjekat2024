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
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        private readonly ASPContext _context;
        public UpdateReservationDtoValidator(ASPContext context) 
        { 
            _context = context;

            RuleFor(x => x.Id).Must(id => _context.Reservations.Any(m => m.Id == id))
                .WithMessage("Reservation with provided id does not exist in database.");
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
