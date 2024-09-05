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
    public class DeleteMealTimeDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;

        public DeleteMealTimeDtoValidator(ASPContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .Must(Exists)
                .WithMessage("Meal time with an id of {PropertyValue} does not exist.");
                
        }
        private bool Exists(int id)
        {
            return _context.MealTimes.Any(x => x.Id == id);
        }

        
    }
}
