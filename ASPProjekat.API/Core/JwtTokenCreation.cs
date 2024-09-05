using ASPProjekat.Domain;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Newtonsoft.Json;

namespace ASPProjekat.API.Core
{
    public class JwtTokenCreation
    {
        private readonly ASPContext _context;
        private readonly JwtSettings _settings;
        private readonly IToken _storage;

        public JwtTokenCreation(ASPContext context, JwtSettings settings, IToken storage)
        {
            _context = context;
            _settings = settings;
            _storage = storage;
        }

        public string Create(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email).Select(x => new
            {
                x.Password,
                x.Name,
                x.Surname,
                x.Id,
                UseCaseIds = x.UseCases.Select(x => x.UseCaseId)
            }).FirstOrDefault();
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException();
            }
            Guid tokenGuid = Guid.NewGuid();

            string tokenId = tokenGuid.ToString();
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String),
                 new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer, ClaimValueTypes.String),
                 new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                 new Claim("Email", email),
                 new Claim("Name", user.Name),
                 new Claim("LastName", user.Surname),             
                 new Claim("Id", user.Id.ToString()),
                 new Claim("UseCaseIds", JsonConvert.SerializeObject(user.UseCaseIds)),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(_settings.Seconds),
                signingCredentials: credentials);

            _storage.Add(tokenGuid);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
