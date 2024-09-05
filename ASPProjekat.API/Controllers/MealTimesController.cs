using ASPProjekat.Application.DTO;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
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
    public class MealTimesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public MealTimesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<MealTimesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetMealTimesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<MealTimesController>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id, [FromServices] IGetOneMealTimeQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }
        // POST api/<MealTimesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateMealTimeDto dto, [FromServices] ICreateMealTimeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MealTimesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] MealTimeDto dto, [FromServices] IUpdateMealTimeCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<MealTimesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteMealTimeCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
