using Cwk.Application.Interfaces;
using Cwk.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cwk.Application.Services
{
    public class TokenServices(IConfiguration config) : ITokenServices
    {
        private readonly string secretKey = config.GetSection("Jwt").GetValue<string>("key")!;

        public string GenerateToken(User user)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            claims.AddClaim(new Claim("Nombre", user.Name));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenConfig);

        }
    }
}
