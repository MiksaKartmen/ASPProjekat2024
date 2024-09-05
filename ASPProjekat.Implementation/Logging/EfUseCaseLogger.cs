using ASPProjekat.Application;
using ASPProjekat.DataAccess;
using ASPProjekat.Domain;
using ASPProjekat.Implementation.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Logging
{
    public class EfUseCaseLogger : EfUseCase, IUseCaseLogger
    {
        public EfUseCaseLogger(ASPContext context) : base(context)
        {
        }

        public void Log(Application.UseCaseLog log)
        {
            var logg = new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                ExecutedAt = DateTime.UtcNow,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData)
            };
            Context.UseCaseLogs.Add(logg);

            Context.SaveChanges();

        }
    }
}

