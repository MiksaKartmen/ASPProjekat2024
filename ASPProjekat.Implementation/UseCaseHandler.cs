using ASPProjekat.Application;
using ASPProjekat.Application.Logging;
using ASPProjekat.Application.UseCases;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation
{
    public class UseCaseHandler
    {
        private readonly IUserApplication _user;
        private readonly IUseCaseLogger _logger;
        private readonly IExceptionLogger _exception;
        private readonly IHttpContextAccessor _contextAccessor;
        public UseCaseHandler(IHttpContextAccessor httpContextAccessor, IUserApplication user, IUseCaseLogger logger, IExceptionLogger exception)
        {
            _logger = logger;
            _user = user;
            _exception = exception;
            _contextAccessor = httpContextAccessor;
        }


        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleCrossCuttingConcerns(command, data);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                command.Execute(data);
                stopWatch.Stop();

                Console.WriteLine(command.Name + $" Execution time: {stopWatch.ElapsedMilliseconds} ms");


            }
            catch (Exception e)
            {
                _exception.Log(e);
                throw;
            }

        }
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleCrossCuttingConcerns(query, data);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var response = query.Execute(data);
                stopWatch.Stop();

                Console.WriteLine(query.Name + $" Execution time: {stopWatch.ElapsedMilliseconds} ms");

                return response;
            }
            catch (Exception e)
            {
                _exception.Log(e);
                throw;
            }

        }
        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {
            var httpMethod = _contextAccessor.HttpContext.Request.Method;
            if (httpMethod != HttpMethods.Get && !_user.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }

            var log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = useCase.Name,
                Username = _user.FirstName,
            };

            _logger.Log(log);
        }
    }
}

