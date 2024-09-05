using ASPProjekat.Application.DTO;
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
    public class EfDeleteUserImageCommand : EfUseCase, IDeleteUserImageCommand
    {
        private readonly DeleteUserImageDtoValidator _validator;

        public EfDeleteUserImageCommand(ASPContext context, DeleteUserImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 43;

        public string Name => "Delete user image";

        public string Description => "Delete user image";

        public void Execute(DeleteDto obj)
        {
            _validator.ValidateAndThrow(obj);
            var picture = Context.UserImages.Find(obj.Id);
            Context.UserImages.Remove(picture);
            Context.SaveChanges();

        }
    }
}
