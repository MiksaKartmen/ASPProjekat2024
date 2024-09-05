using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application
{
    public interface IUserApplication
    {
        int Id { get; }
        string Email { get; }
        string FirstName { get; }
        string Username { get; }
        string LastName { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
