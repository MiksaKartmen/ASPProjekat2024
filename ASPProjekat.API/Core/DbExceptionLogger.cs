using ASPProjekat.Application;
using ASPProjekat.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPProjekat.API.Core
{
    public class DbExceptionLogger : ILogger
    {
        private readonly ASPContext _context;

        public DbExceptionLogger(ASPContext context)
        {
            _context = context;

        }

        public Guid Log(Exception ex, IUserApplication actor)
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

            return id;
        }
    }
}
