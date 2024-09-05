using ASPProjekat.API.Core;
using ASPProjekat.API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly JwtTokenCreation _tokenCreator;

        public AuthorizationController(JwtTokenCreation tokenCreator)
        {
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthorizationRequest request)
        {
            string token = _tokenCreator.Create(request.Email, request.Password);

            return Ok(new AuthorizationResponse { Token = token });
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] IToken storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);

            return NoContent();
        }
    }
}
