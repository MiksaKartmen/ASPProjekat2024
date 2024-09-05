using ASPProjekat.Application.DTO.Insert;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateTableDtoValidator : AbstractValidator<CreateTableDto>
    {
        public CreateTableDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Table name is required");

            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage("Capacity is required")
                .GreaterThan(1)
                .WithMessage("Capacity of the table must be greater than 1")
                .LessThan(13)
                .WithMessage("Capacity of the table must be less than 13");
        }
    }
}
