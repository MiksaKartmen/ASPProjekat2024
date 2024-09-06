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
    public class ReservationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ReservationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<ReservationsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetReservationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneReservationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ReservationsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateReservationDto dto, [FromServices] ICreateReservationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateReservationDto dto, IUpdateReservationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteReservationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
