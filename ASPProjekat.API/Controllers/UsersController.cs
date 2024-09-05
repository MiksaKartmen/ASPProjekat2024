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
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _handler;
        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));

        }

        // POST api/<UsersController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateUserDto dto, ICreateUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteUserCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
