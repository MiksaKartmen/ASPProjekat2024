using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.UseCases
{
    public interface ICommand<TObj> : IUseCase
    {
        void Execute(TObj obj);
    }
}
