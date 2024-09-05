using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfCreateMealTimeCommand : EfUseCase, ICreateMealTimeCommand
    {
        private CreateMealTimeDtoValidator _validator;
        public EfCreateMealTimeCommand(ASPContext context, CreateMealTimeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Create meal time";

        public string Description => "Create meal time";

        public void Execute(CreateMealTimeDto obj)
        {
            _validator.ValidateAndThrow(obj);
            Context.MealTimes.Add(new MealTime
            {
                Name = obj.Name,
                Description = obj.Description,
                TimeFrom = obj.TimeFrom,
                TimeTo = obj.TimeTo,
            });

            Context.SaveChanges();
        }
    }
}
