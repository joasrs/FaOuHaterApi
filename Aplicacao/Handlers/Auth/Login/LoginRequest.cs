using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Auth.Login
{
    public class LoginRequest : IRequest<ActionResult<AuthResponse>>
    {
        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;
    }
}
