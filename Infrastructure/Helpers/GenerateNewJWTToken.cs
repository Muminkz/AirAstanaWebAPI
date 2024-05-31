using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace Infrastructure.Helpers
{
    public class GenerateNewJWTToken
    {
        public static string GenerateJWTToken(string UserName, string Password, string SecurityKey)
        {
            var claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, Password),
                        new Claim(ClaimTypes.Name, UserName),
                };
            var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(SecurityKey)
                    ),
                SecurityAlgorithms.HmacSha256Signature)
            );
            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
