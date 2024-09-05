using ASPProjekat.Application.DTO;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public TablesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<TablesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetTablesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<TablesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateTableDto dto, ICreateTableCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateTableDto dto, [FromServices] IUpdateTableCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteTableCommand command)
        {
            dto.Id=id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
