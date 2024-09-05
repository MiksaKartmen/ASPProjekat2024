using ASPProjekat.Application.DTO.Updates;
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
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserDtoValidator _validator;

        public EfUpdateUserCommand(ASPContext context, UpdateUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Update user";

        public string Description => "Update user";

        public void Execute(UpdateUserDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var user = Context.Users.Find(obj.Id);

            user.Name = obj.Name;
            user.Surname = obj.Surname;
            user.Email = obj.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);
            user.Phone = obj.Phone;

            Context.SaveChanges();
           
        }
    }
}
