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
    public class EmployeesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public EmployeesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetEmployeesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }



        // POST api/<EmployeesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateEmployeeDto dto, [FromServices] ICreateEmployeeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateEmployeeDto dto, IUpdateEmployeeCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteEmployeeCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
