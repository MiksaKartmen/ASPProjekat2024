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
    public class PricesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PricesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<PricesController>
        [HttpGet]
        public IActionResult Get([FromQuery] PriceSearch search, [FromServices] IGetPriceQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<PricesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePriceDto dto, [FromServices] ICreatePriceCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        // DELETE api/<PricesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeletePriceCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
