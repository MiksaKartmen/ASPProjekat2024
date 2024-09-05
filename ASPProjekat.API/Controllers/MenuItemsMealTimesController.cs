using ASPProjekat.Application.DTO;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsMealTimesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public MenuItemsMealTimesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // POST api/<MenuItemsMealTimesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateMenuItemMealTimeDto dto, [FromServices] ICreateMenuItemMealTimeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MenuItemsMealTimesController>/5
        [HttpPut("{id}")]
        
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuItemsMealTimesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteMenuItemMealTimeCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
