using ASPProjekat.Application.DTO.Gets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.UseCases.Queries
{
    public interface IGetOneUserQuery : IQuery<int, UserDto>
    {
    }
}
