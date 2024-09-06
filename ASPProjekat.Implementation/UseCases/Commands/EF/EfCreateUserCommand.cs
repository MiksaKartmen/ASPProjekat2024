using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.Mail;
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
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private readonly CreateUserDtoValidator _validator;
        private readonly IEmailService _emailService;

        public EfCreateUserCommand(ASPContext context, CreateUserDtoValidator validator, IEmailService emailService) : base(context)
        {
            _validator = validator;
            _emailService = emailService;
        }

        public int Id => 29;

        public string Name => "Create user";

        public string Description => "Create user";

        public void Execute(CreateUserDto obj)
        {
            _validator.ValidateAndThrow(obj);

            var user = new Domain.User
            {
                Name = obj.Name,
                Surname = obj.Surname,
                Email = obj.Email,
                Phone = obj.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword(obj.Password),
                RoleId = obj.RoleId,
                UseCases = new List<UserUseCase>()
                {
                    new UserUseCase { UseCaseId = 2 },
                    new UserUseCase { UseCaseId = 4 },
                    new UserUseCase { UseCaseId = 5 },
                    new UserUseCase { UseCaseId = 9 },
                    new UserUseCase { UseCaseId = 10 },
                    new UserUseCase { UseCaseId = 11 },
                    new UserUseCase { UseCaseId = 12 },
                    new UserUseCase { UseCaseId = 13 },
                    new UserUseCase { UseCaseId = 15 },
                    new UserUseCase { UseCaseId = 16 },
                    new UserUseCase { UseCaseId = 17 },
                    new UserUseCase { UseCaseId = 21 },
                    new UserUseCase { UseCaseId = 23 },
                    new UserUseCase { UseCaseId = 24 },
                    new UserUseCase { UseCaseId = 25 },
                    new UserUseCase { UseCaseId = 26 },
                    new UserUseCase { UseCaseId = 27 },
                    new UserUseCase { UseCaseId = 28 },
                    new UserUseCase { UseCaseId = 29 },
                    new UserUseCase { UseCaseId = 31 },
                    new UserUseCase { UseCaseId = 32 },
                    new UserUseCase { UseCaseId = 34 },
                    new UserUseCase { UseCaseId = 35 },
                    new UserUseCase { UseCaseId = 36 },
                    new UserUseCase { UseCaseId = 38 },
                    new UserUseCase { UseCaseId = 39 },
                    new UserUseCase { UseCaseId = 40 },
                    new UserUseCase { UseCaseId = 43 },
                    new UserUseCase { UseCaseId = 42 },
                    new UserUseCase { UseCaseId = 45 },
                    new UserUseCase { UseCaseId = 46 },
                    new UserUseCase { UseCaseId = 47 },
                    new UserUseCase { UseCaseId = 52 },
                    new UserUseCase { UseCaseId = 53 },
                    new UserUseCase { UseCaseId = 54 },
                    new UserUseCase { UseCaseId = 55 },
                    new UserUseCase { UseCaseId = 56 },
                    new UserUseCase { UseCaseId = 57 },
                    new UserUseCase { UseCaseId = 59 },


                },
            };
            Context.Users.Add(user);
            Context.SaveChanges();

            try
            {
                var emailSubject = "Welcome to AspProjekat2024!";
                var emailBody = $"Dear {user.Name},\n\nThank you for registering with us.\n\nBest regards,\nAspProjekat Team";
                _emailService.SendEmailAsync(user.Email, emailSubject, emailBody).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}
