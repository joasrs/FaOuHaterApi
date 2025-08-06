using FaOuHaterApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FaOuHaterApi.Services.Auth
{
    public static class AuthService
    {
        public static string GerarToken( Usuario usuario )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes( "1wish-you-were-here2" );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new[] { new Claim( ClaimTypes.Name, usuario.Login ) } ),
                Expires = DateTime.UtcNow.AddHours( 2 ),
                Issuer = "FaOuHaterApi",
                Audience = "fa_ou_hater.frontend",
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )
            };

            var token = tokenHandler.CreateToken( tokenDescriptor );
            return tokenHandler.WriteToken( token );
        }

    }
}
