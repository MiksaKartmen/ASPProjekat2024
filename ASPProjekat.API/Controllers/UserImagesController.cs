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
    public class UserImagesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public UserImagesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UserImagesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetUserImagesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

       

        // POST api/<UserImagesController>
        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] CreateUserImageDto dto, [FromServices] ICreateUserImageCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UserImagesController>/5
        [HttpPut("{id}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Put(int id, [FromForm] UpdateUserImageDto dto, [FromServices] IUpdateUserImageCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<UserImagesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteUserImageCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }
    }
}
