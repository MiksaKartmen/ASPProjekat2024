using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetAuditLogsQuery : EfUseCase, IGetAuditLogsQuery
    {
        public EfGetAuditLogsQuery(ASPContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Get logs";

        public string Description => "Get logs";

        public IEnumerable<AuditLogDto> Execute(AuditLogsSearch search)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.User) || !string.IsNullOrWhiteSpace(search.User))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.User.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.DateFrom) || !string.IsNullOrWhiteSpace(search.DateFrom))
            {
                query = query.Where(x => x.ExecutedAt >= DateTime.Parse(search.DateFrom));
            }

            if (!string.IsNullOrEmpty(search.DateTo) || !string.IsNullOrWhiteSpace(search.DateTo))
            {
                query = query.Where(x => x.ExecutedAt <= DateTime.Parse(search.DateTo));
            }

            var skipCount = (search.Page.GetValueOrDefault(1) - 1) * search.ItemsPerPage.GetValueOrDefault(5);
            query = query.Skip(skipCount).Take(search.ItemsPerPage.GetValueOrDefault(12));

            return query.Select(x => new AuditLogDto
            {
                Id = x.Id,
                User = x.Username,
                UseCaseName = x.UseCaseName,
                Data = x.UseCaseData,
                ExecutedAt = x.ExecutedAt
            });
        }
    }
}
