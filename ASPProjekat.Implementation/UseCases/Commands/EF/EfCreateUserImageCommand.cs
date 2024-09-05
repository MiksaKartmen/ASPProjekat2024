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
    public class EfCreateUserImageCommand : EfUseCase, ICreateUserImageCommand
    {
        private readonly CreateUserImageDtoValidator _validator;

        public EfCreateUserImageCommand(ASPContext context, CreateUserImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Create user image";

        public string Description => "Create user image";

        public void Execute(CreateUserImageDto obj)
        {
            _validator.ValidateAndThrow(obj);

            if (obj.Src != null)
            {
                var extension = Path.GetExtension(obj.Src.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "userImages", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    obj.Src.CopyTo(fs);
                }
                Context.UserImages.Add(new UserImage
                {
                    Src = "/images/" + filename,
                    UserId = obj.UserId,
                });

                Context.SaveChanges();

            }
        }
    }
}
