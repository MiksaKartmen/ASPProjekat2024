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
    public class DeleteUserDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly ASPContext _context;
        public DeleteUserDtoValidator(ASPContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .Must(Exists)
                .WithMessage("User with an id of {PropertyValue} does not exist.");
                
        }

     

        private bool Exists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}
