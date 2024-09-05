using ASPProjekat.Application.Logging;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        private readonly ASPContext _context;
        public ConsoleExceptionLogger(ASPContext context)
        {
            _context = context;
        }
        public void Log(Exception ex)
        {
            Guid id = Guid.NewGuid();
            var log = new ErrorLog
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow,
            };
            _context.ErrorLogs.Add(log);

            _context.SaveChanges();
        }
    }
}
