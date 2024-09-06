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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASPProjekat.Implementation.UseCases.Commands.EF
{
    public class EfUpdateMealTimeCommand : EfUseCase, IUpdateMealTimeCommand
    {
        private readonly UpdateMealTimeDtoValidator _validator;
        public EfUpdateMealTimeCommand(ASPContext context, UpdateMealTimeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 56;

        public string Name => "Update meal time";

        public string Description => "Update meal time";

        public void Execute(MealTimeDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var mealTime = Context.MealTimes.Find(obj.Id);

            mealTime.Name = obj.Name;
            mealTime.Description = obj.Description;
            mealTime.TimeFrom = obj.TimeFrom;
            mealTime.TimeTo = obj.TimeTo;

            Context.SaveChanges();
        }
    }
}
