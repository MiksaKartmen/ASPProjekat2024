using ASPProjekat.Application.DTO.Insert;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateEmployeeRoleDtoValidator : AbstractValidator<CreateEmployeeRoleDto>
    {
        public CreateEmployeeRoleDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Employee role name is required.");


        }
    }
}
