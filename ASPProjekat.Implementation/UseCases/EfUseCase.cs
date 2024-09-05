using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases
{
    public class EfUseCase
    {
        protected EfUseCase(ASPContext context)
        {
            Context = context;
        }
        protected ASPContext Context { get; }
    }
}
