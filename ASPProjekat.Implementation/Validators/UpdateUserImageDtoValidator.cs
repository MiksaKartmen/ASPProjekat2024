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
    public class UpdateUserImageDtoValidator : AbstractValidator<UpdateUserImageDto>
    {
        private readonly ASPContext _context;
        public UpdateUserImageDtoValidator(ASPContext context)
        {
            _context = context;


            RuleFor(x => x.UserId)
                .Must(UserExists)
                .WithMessage("User with an id  does not exist.");
        }
        public bool UserExists(int userId)
        {
            return _context.Users.Any(x => x.Id == userId);
        }
    }
}
