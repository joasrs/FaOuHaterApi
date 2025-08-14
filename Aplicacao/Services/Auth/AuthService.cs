using Domain.Interfaces;
using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplicacao.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthService(IConfiguration configuration)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _configuration = configuration;
        }

        public string GerarToken(Usuario usuario)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(60);

            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, usuario.Id.ToString()) };

            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             claims: claims,
                                             expires: expiry,
                                             signingCredentials: credentials);

            var stringToken = _tokenHandler.WriteToken(token);
            return stringToken;
        }

        public string Hash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public bool ValidarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
