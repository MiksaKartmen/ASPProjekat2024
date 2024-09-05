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
    public class MenuItemController : ControllerBase
    {
        private UseCaseHandler _handler;

        public MenuItemController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public IActionResult Get([FromQuery] MenuItemsSearch search, [FromServices] IGetMenuItemsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneMenuItemQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<MenuItemController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateMenuItemDto dto, ICreateMenuItemCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateMenuItemDto dto, [FromServices] IUpdateMenuItemCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteMenuItemCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
