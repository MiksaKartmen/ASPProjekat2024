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
    public class UpdateTableDtoValidator : AbstractValidator<UpdateTableDto>
    {
        private readonly ASPContext _context;

        public UpdateTableDtoValidator(ASPContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage("Capacity is required");

            RuleFor(x => x.Id).Must(Exists).WithMessage("Table with an id of {PropertyValue} does not exist");
            

        }

        private bool Exists(int id)
        {
            return _context.Tables.Any(x => x.Id == id);
        }
    }
}
