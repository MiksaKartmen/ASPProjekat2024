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
    public class EfUpdateUserImageCommand : EfUseCase, IUpdateUserImageCommand
    {
        private readonly UpdateUserImageDtoValidator _validator;

        public EfUpdateUserImageCommand(ASPContext context, UpdateUserImageDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 42;

        public string Name => "Update user image";

        public string Description => "Update user image";

        public void Execute(UpdateUserImageDto obj)
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

                var picture1 = Context.UserImages.Find(obj.Id);
                picture1.Src = "/userImages/" + filename;


                Context.SaveChanges();
            }
        }
    }
}
