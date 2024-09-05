using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public AuditLogsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<AuditLogsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] AuditLogsSearch search, [FromServices] IGetAuditLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


    }
}
