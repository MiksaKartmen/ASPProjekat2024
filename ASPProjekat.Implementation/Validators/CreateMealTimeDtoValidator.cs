using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateMealTimeDtoValidator : AbstractValidator<CreateMealTimeDto>
    {
        private readonly ASPContext _context;
        public CreateMealTimeDtoValidator(ASPContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Meal time name is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                        .Must((dto, name) => !_context.MealTimes.Any(b => b.Name == name))
                        .WithMessage(dto => $"Meal time with name {dto.Name} already exists in database.");
                });

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Meal description name is required");

            RuleFor(x => x.TimeFrom)
                .NotEmpty()
                .WithMessage("Meal time from is required");

            RuleFor(x => x.TimeTo)
                .NotEmpty()
                .WithMessage("Meal time to is required");
               
        }
    }
}
