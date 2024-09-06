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
    public class DeleteReservationDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;

        public DeleteReservationDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Reservation Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.Reservations.Any(p => p.Id == id))
                        .WithMessage("Reservation with an id of {PropertyValue} doesn't exist.");
                });
        }
    }
}
