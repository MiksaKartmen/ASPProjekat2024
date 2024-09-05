using ASPProjekat.Application.DTO;
using ASPProjekat.Application.DTO.Insert;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.DTO.Updates;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryImagesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public GalleryImagesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<GalleryImagesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetGalleryImagesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // POST api/<GalleryImagesController>
        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] CreateGalleryImageDto dto, [FromServices] ICreateGalleryImageCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<GalleryImagesController>/5
        [HttpPut("{id}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Put(int id, [FromForm] UpdateGalleryImageDto dto, [FromServices] IUpdateGalleryImageCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<GalleryImagesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromBody] DeleteDto dto, [FromServices] IDeleteGalleryImageCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
