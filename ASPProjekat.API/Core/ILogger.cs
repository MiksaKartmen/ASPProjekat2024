using ASPProjekat.Application;

namespace ASPProjekat.API.Core
{
    public interface ILogger
    {
        Guid Log(Exception ex, IUserApplication actor);

    }
}
