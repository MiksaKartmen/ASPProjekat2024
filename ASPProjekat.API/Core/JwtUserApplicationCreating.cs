using ASPProjekat.Application;
using ASPProjekat.Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace ASPProjekat.API.Core
{
    public class JwtUserApplicationCreating : IUserApplicationCreating
    {
        private string authorizationHeader;

        public JwtUserApplicationCreating(string authorizationHeader)
        {
            this.authorizationHeader = authorizationHeader;
        }

        public IUserApplication GetUser()
        {
            if (authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedUser();
            }

            string token = authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var user = new User
            {
                Email = claims.First(x => x.Type == "Email").Value,
                FirstName = claims.First(x => x.Type == "Name").Value,
                LastName = claims.First(x => x.Type == "LastName").Value,
                Id = int.Parse(claims.First(x => x.Type == "Id").Value),
                AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.First(x => x.Type == "UseCaseIds").Value)
            };

            return user;
        }
    }
}
