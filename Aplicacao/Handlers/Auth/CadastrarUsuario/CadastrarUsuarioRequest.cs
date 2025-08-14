using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Auth.CadastrarUsuario
{
    public class CadastrarUsuarioRequest : IRequest<ActionResult<AuthResponse>>
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;
    }
}
